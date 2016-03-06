using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bm2s.Poco.Common.Parameter;

namespace Bm2sWinBO.Utils
{
  public static class TranslationUtils
  {
    public const string ApplicationName = "bm2swinbo";

    private static List<Translation> _translations;

    public static string Get(string screen, string key, string defaultValue, params string[] parameters)
    {
      return TranslationUtils.Get(screen, key, UserUtils.CurrentUser.DefaultLanguage, defaultValue);
    }

    public static string Get(string screen, string key, Bm2s.Poco.Common.Parameter.Language language, string defaultValue, params string[] parameters)
    {
      if(_translations == null)
      {
        _translations = new List<Translation>();
      }

      Translation result;
      if(_translations.Any(item => item.Screen == screen && item.Key == key && item.Language.Id == language.Id))
      {
        result = _translations.First(item => item.Screen == screen && item.Key == key && item.Language.Id == language.Id);
      }
      else
      {
        Bm2s.Connectivity.Common.Parameter.Translation translation = new Bm2s.Connectivity.Common.Parameter.Translation();
        translation.Request.Application = TranslationUtils.ApplicationName;
        translation.Request.LanguageId = language.Id;
        translation.Request.Screen = screen;
        translation.Request.Key = key;
        translation.Get();

        if (!translation.Response.Translations.Any())
        {
          translation.Request.Translation = new Bm2s.Poco.Common.Parameter.Translation()
          {
            Application = TranslationUtils.ApplicationName,
            Key = key,
            Language = language,
            Screen = screen,
            Value = "[" + language.Code + "_" + defaultValue + "]"
          };
          translation.Post();
        }

        result = translation.Response.Translations.FirstOrDefault();
        _translations.Add(translation.Response.Translations.FirstOrDefault());
      }

      return string.Format(result.Value, parameters);
    }

    public static string Get(string screen, string key, string languageCode, string defaultValue, params string[] parameters)
    {
      Bm2s.Connectivity.Common.Parameter.Language language = new Bm2s.Connectivity.Common.Parameter.Language();
      language.Request.Code = languageCode;
      language.Get();

      Bm2s.Poco.Common.Parameter.Language lang = language.Response.Languages.FirstOrDefault();

      if (lang == null)
      {
        lang = UserUtils.CurrentUser.DefaultLanguage;
      }

      return TranslationUtils.Get(screen, key, lang, defaultValue, parameters);
    }

    public static string Get(string screen, string key, int languageId, string defaultValue, params string[] parameters)
    {
      Bm2s.Connectivity.Common.Parameter.Language language = new Bm2s.Connectivity.Common.Parameter.Language();
      language.Request.Ids.Add(languageId);
      language.Get();

      Language lang = language.Response.Languages.FirstOrDefault();

      if (lang == null)
      {
        lang = UserUtils.CurrentUser.DefaultLanguage;
      }

      return TranslationUtils.Get(screen, key, lang, defaultValue, parameters);
    }

    public static int Set(string screen, string key, Bm2s.Poco.Common.Parameter.Language language, string value)
    {
      Bm2s.Connectivity.Common.Parameter.Translation translation = new Bm2s.Connectivity.Common.Parameter.Translation();
      translation.Request.Application = TranslationUtils.ApplicationName;
      translation.Request.Screen = screen;
      translation.Request.Key = key;
      translation.Request.LanguageId = language.Id;
      translation.Get();
      Bm2s.Poco.Common.Parameter.Translation tran = translation.Response.Translations.FirstOrDefault();

      translation.Request.Translation = new Translation();
      translation.Request.Translation.Application = TranslationUtils.ApplicationName;
      translation.Request.Translation.Screen = screen;
      translation.Request.Translation.Key = key;
      translation.Request.Translation.Language = language;
      translation.Request.Translation.Value = value;
      if (tran != null)
      {
        translation.Request.Translation.Id = tran.Id;
      }
      translation.Post();

      _translations.Add(translation.Response.Translations.FirstOrDefault());

      return translation.Response.Translations.FirstOrDefault().Id;
    }

    public static void Translate(Form form)
    {
      form.Text = Get(form.Name, "Title", form.Text);

      foreach(Control ctrl in form.Controls)
      {
        if (!(ctrl is TextBoxBase))
        {
          ctrl.Text = Get(form.Name, ctrl.Name, ctrl.Text);
        }
      }
    }
  }
}
