﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    class User
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        public List<BookSample> FavoriteBooks { get; set; }
        public List<BookSample> BorrowedBooks { get; set; }
        public List<BookSample> ReservedBooks { get; set; }
        public List<BookSample> HistoryBooks { get; set; }
        public decimal Money { get; set; }



        public User(string name, string surname, string login, string password, decimal money)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Money = money;

        }

        public void BorrowBook(Book book)
        {
            book.Quantity--;
            BookSample book1 = book.BookSample;
            BorrowedBooks.Add(book1);
            HistoryBooks.Add(book1);
            Money -= book1.Cost * (book1.Calendar.EndingDate.Day - book1.Calendar.DateOfBorrow.Day);
            Library.Capital += book1.Cost * (int)(book1.Calendar.EndingDate - book1.Calendar.DateOfBorrow).TotalDays;
            string history = book1.Name + " - " + book1.Author + " - " + Login + book1.Calendar.DateOfBorrow.ToShortDateString() + book1.Calendar.EndingDate.ToShortDateString();
            Library.History.Add(history);

        }

        public void Reserve(Book book,DateTime EndingDate) {
            book.ReservedUser.Enqueue(this);
            book.EndingDates.Enqueue(EndingDate);


        }







    }
}
