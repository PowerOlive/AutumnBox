/* =============================================================================*\
*
* Filename: LanguageHelper.cs
* Description: 
*
* Version: 1.0
* Created: 9/23/2017 21:21:10(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using AutumnBox.Support.CstmDebug;
using System;
using System.Windows;

namespace AutumnBox.GUI.I18N
{
    [LogProperty(TAG = "Language Manage")]
    /// <summary>
    /// 界面的语言切换帮助类
    /// </summary>
    public static class LanguageHelper
    {
        public static event EventHandler LanguageChanged;
        public static readonly Language[] Langs;
        public static readonly string Prefix = "pack://application:,,,/AutumnBox.GUI;component/I18N/Langs/";
        static LanguageHelper()
        {
            //Langs = new Language[]{
            //    new Language("zh-CN.xaml"),
            //    new Language("en-US.xaml")
            //};
        }
        public static void LoadLanguage(Language lang)
        {
            App.Current.Resources.MergedDictionaries[0] = LoadLangFromResource(lang);
            LanguageChanged?.Invoke(new object(), new EventArgs());
        }
        public static ResourceDictionary LoadLangFromResource(Language lang)
        {
            Logger.D( lang.FileName);
            return LoadLangFromResource(lang.FileName);
        }
        public static ResourceDictionary LoadLangFromResource(string fileName)
        {
            Logger.D( fileName);
            var lang = new ResourceDictionary { Source = new Uri(Prefix + fileName) };
            return lang;
        }
    }
}
