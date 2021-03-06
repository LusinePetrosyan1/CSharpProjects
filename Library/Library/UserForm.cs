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
            user1 = user ;
            InitializeComponent();
            label1.Text = user1.Name;
            label2.Text = user1.Surname;
            label3.Text = user1.Money + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user1.PrintFavoriteBooks();
            Update();
        }

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
            AddMoneyForm.money = 0;
            UpdateMoney();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Book> book=new List<Book>();
            foreach (Book b in Library.Books)
            {
                if (b.BookSample.Name.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    book.Add(b);
                }
            }
            BookSearchForm bsf = new BookSearchForm(book,user1);
            bsf.ShowDialog();
            UpdateMoney();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user1.PrintBorrowedBooks();
            UpdateMoney();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user1.PrintHistoryOfBorrowedBooks();
            UpdateMoney();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            user1.PrintReservedBooks();
            UpdateMoney();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 thirdform = new Form1();
            this.Hide();
            thirdform.ShowDialog();
            this.Close();
        }

        private void UserForm_Load_1(object sender, EventArgs e)
        {

        }
        public void UpdateMoney()
        {
            label3.Text = user1.Money + "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GiveBookUserForm gbuf = new GiveBookUserForm(user1.BorrowedBooks, user1);
            gbuf.ShowDialog();
        }
    }
}
