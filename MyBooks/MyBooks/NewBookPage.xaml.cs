using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBooks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public NewBookPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Name = bookName.Text,
                Author = authorName.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                conn.CreateTable<Book>(); // Caso ja tiver a tabela no banco nao criara;
                var numberOfRows = conn.Insert(book);

                if (numberOfRows > 0)
                    DisplayAlert("Inserido", "Livro inserido com sucesso.", "Ok");
                else
                    DisplayAlert("Erro", "O livro não pôde ser inserido.", "Ok");
            }
        }
    }
}