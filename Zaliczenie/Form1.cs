using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaliczenie
{
    public partial class Form1 : Form
    {
        Dictionary<int, Person> People = new Dictionary<int, Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> peopleGrid = new List<Person>();

            foreach (var item in People) {
                peopleGrid.Add(item.Value);
            }

            personBindingSource.DataSource = peopleGrid.ToList();
        }

        private void load_people() {
            Person jarek = new Person("Jarek", "Kowalski", 1);
            Person andrzej = new Person("Andrzej", "Malinowski", 2);
            jarek.Books.Add(new Book("Harry Potter and the Philosopher's Stone", 200, 0, 1, 1, 1997));
            jarek.Books.Add(new Book("Harry Potter and the Chamber of Secrets", 230, 0, 1, 1, 1998));
            andrzej.Books.Add(new Book("The Hobbit", 340, 0, 1, 1, 1937));
            andrzej.Books.Add(new Book("The Fellowship of the Ring", 400, 0, 1, 1, 1954));
            andrzej.Fines.Add(new Fine(5,"The Hobbit"));

            People.Add(jarek.LibraryId, jarek);
            People.Add(andrzej.LibraryId, andrzej);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_people();
            button1_Click(new object(), new EventArgs());

        }

        private void personBindingSource_PositionChanged(object sender, EventArgs e)
        {
            var current = personBindingSource.Current;
            if (((Person)current) != null)
            {
                bookBindingSource.DataSource = ((Person)current).Books;
                fineBindingSource.DataSource = ((Person)current).Fines;
            }
            else
            {
                bookBindingSource.DataSource = null;
                fineBindingSource.DataSource = null;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var current = personBindingSource.Current;

            if (((Person)current) != null)
            {
                People.Remove(((Person)current).LibraryId);
            }
            button1_Click(new object(), new EventArgs());
            personBindingSource_PositionChanged(new object(), new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Big data :-)
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                Person newPerson;
                int random_num;
                do
                {
                    Random random = new Random();
                    random_num = random.Next(0, 4000000);
                    People.TryGetValue(random_num, out newPerson);
                    Console.WriteLine(newPerson != null);
                } while (newPerson != null);
            
                newPerson = new Person(textBox1.Text, textBox2.Text, random_num);
                People.Add(random_num, newPerson);
                button1_Click(new object(), new EventArgs());
                label3.Text = "";

            }
            else {
                label3.Text = "Error: Data Incorrect";
            }
            
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            button1_Click(new object(), new EventArgs());
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            var current = personBindingSource.Current;

            if (((Person)current) != null)
            {

                textBox4.Text = ((Person)current).Name;
                textBox3.Text = ((Person)current).SurName;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var current = personBindingSource.Current;
            if (((Person)current) != null )
            {
                if (textBox4.Text.Length > 0 && textBox3.Text.Length > 0)
                {
                    ((Person)current).Name = textBox4.Text;
                    ((Person)current).SurName = textBox3.Text;
                    label9.Text = "";
                }
                else
                {
                    label9.Text = "Error: Data Incorrect";
                }
            }
            button1_Click(new object(), new EventArgs());

        }
    }
}
