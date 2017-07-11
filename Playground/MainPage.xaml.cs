using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Newtonsoft.Json;
using Playground.Models;
using Playground.Templates;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Playground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Unified> Unifieds { get; }

        public MainPage()
        {
            this.InitializeComponent();

            var list = new List<Unified>();

            for (var i = 0; i < 100; i++)
            {
                list.Add(GetRandomBool() ? new Unified(GetInstance1()) : new Unified(GetInstance2()));
            }

            Unifieds = list;
        }

        private static Follow GetInstance1()
        {
            var instance = new Follow
            {
                Id = new Random(DateTime.Now.Millisecond).Next(100, 1000),
                Name = $"Item{new Random(DateTime.Now.Millisecond).Next(0xA, 0x64)}_{new Random(DateTime.Now.Millisecond).Next(1, 10)}@Follow",
                FollowCount = new Random(DateTime.Now.Millisecond).Next(1, 100),
                IsFollowed = GetRandomBool()
            };

            Debug.WriteLine(JsonConvert.SerializeObject(instance));

            return instance;
        }

        private static Like GetInstance2()
        {
            var instance = new Like
            {
                Id = new Random(DateTime.Now.Millisecond).Next(100, 1000),
                Name = $"Item{new Random(DateTime.Now.Millisecond).Next(0xA, 0x64)}_{new Random(DateTime.Now.Millisecond).Next(1, 10)}@Like",
                LikeCount = new Random(DateTime.Now.Millisecond).Next(1, 100),
                IsLiked = GetRandomBool()
            };

            Debug.WriteLine(JsonConvert.SerializeObject(instance));

            return instance;
        }

        private static bool GetRandomBool()
        {
            return new Random(DateTime.Now.Millisecond).Next(0, 2) == 0;
        }
    }
}
