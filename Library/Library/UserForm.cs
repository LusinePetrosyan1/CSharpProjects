﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class UserForm : Form
    {
        User user1;

        public UserForm()
        {
            InitializeComponent();
        }
        public UserForm(User user)
        {
            user1 = user;
            InitializeComponent();
            label1.Text = user1.Name;
            label2.Text = user1.Surname;
            label3.Text = user1.Money + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox listBox1 = new ListBox();
            List<String> b = user1.PrintFavoriteBooks();
            for (int i = 0; i < b.Count; i++)
            {
                listBox1.Items.Add(b[i]);
            }
            listBox1.Show() ;

        private void UserForm_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddMoneyForm a = new AddMoneyForm();
            a.ShowDialog();
            user1.Money += AddMoneyForm.money;
            label3.Text = user1.Money + "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Book> book=new List<Book>();
            foreach (Book b in Library.Books)
            {
                if (b.BookSample.Name.Contains(textBox1.Text))
                {
                    book.Add(b);
                }
            }
            BookSearchForm bsf = new BookSearchForm(book);
            bsf.ShowDialog();
        }
    }
}
