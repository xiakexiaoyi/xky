﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xky.Platform.UserControl
{
    /// <summary>
    /// MyTagItem.xaml 的交互逻辑
    /// </summary>
    public partial class MyDeviceItem : System.Windows.Controls.UserControl
    {
        public MyDeviceItem()
        {
            InitializeComponent();
            DataContext = this;
            ItemList.Add(this);
            
        }

        //用于判断选中状态
        public static readonly List<MyDeviceItem> ItemList = new List<MyDeviceItem>();


        public bool TagIsSelected
        {
            get => (bool) GetValue(TagIsSelectedProperty);
            set => SetValue(TagIsSelectedProperty, value);
        }

        public static readonly DependencyProperty TagIsSelectedProperty =
            DependencyProperty.Register("TagIsSelected", typeof(bool), typeof(MyDeviceItem),
                new PropertyMetadata(false, null));

        internal event OnClick OnClickEvent;

        internal delegate void OnClick(MyDeviceItem sender);

        public void ClickDown(object sender, MouseButtonEventArgs e)
        {
            if (e == null || e.LeftButton == MouseButtonState.Pressed)
            {
                foreach (var myTagItem in ItemList)
                {
                    myTagItem.TagIsSelected = Equals(myTagItem, this);
                }

                if (TagIsSelected)
                {
                    OnClickEvent?.Invoke(this);
                }
            }
        }
    }
}