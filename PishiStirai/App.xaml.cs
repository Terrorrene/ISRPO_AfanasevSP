using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PishiStirai.Context;

namespace PishiStirai
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User CurrentUser = null;
        public static tradeEntities db = new tradeEntities();
    }
}
