﻿using mainModules.Models;
using System;
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
using System.Windows.Shapes;

namespace mainModules
{
    /// <summary>
    /// Interaction logic for frmstock_entry.xaml
    /// </summary>
    public partial class frmstock_entry : Window
    {

        public string WindowTitle = "Add/Edit Item";
        private int listIndex;
        private MainWindow mainWindow;


        public frmstock_entry()
        {
          
            InitializeComponent();
        }

        private void frmStockEntry1_Activated(object sender, EventArgs e)
        {
            frmStockEntry1.Title = WindowTitle;
        }

        public void NewStockItem(MainWindow callingform=null)
        {
            listIndex = -1;
            mainWindow = callingform;

            edtSKU.Text = "";
            edtSKU.IsEnabled = true;
            edtQTYonHand.Text = "";
            edtSellPrice.Text = "";
            edtDescript.Text = "";

        }
        public void LoadStockItem(StockItem itemToLoad, int index, MainWindow callingform=null)
        {
            listIndex = index;
            mainWindow = callingform;

            edtSKU.Text = itemToLoad.Product_SKU;
            edtSKU.IsEnabled = false;
            edtQTYonHand.Text = itemToLoad.Qty_OnHand;
            edtSellPrice.Text = itemToLoad.RetailPrice;
            edtDescript.Text = itemToLoad.Item_Description;


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (listIndex > -1)
            {
                var currStockItem = new StockItem();
                currStockItem.addStockItem(edtSKU.Text, edtQTYonHand.Text, edtSellPrice.Text, edtDescript.Text);

                //mainWindow._stockList[listIndex] = currStockItem;
                //mainWindow.RefreshDataGrid();
                this.Close();
            }
            else
            {
                var currStockItem = new StockItem();
                currStockItem.addStockItem(edtSKU.Text, edtQTYonHand.Text, edtSellPrice.Text, edtDescript.Text);

                //mainWindow._stockList.Add(currStockItem);
                //mainWindow.RefreshDataGrid();
                this.Close();
            }
        }
    }
}
