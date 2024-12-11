using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        StudentContext context = new StudentContext();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = context.Bookings.ToList();

            movieBindingSource.DataSource = context.Movies.ToList();

            var y = from x in context.Movies
                    where x.Title.Contains(textBox1.Text)
                    select x;

            movieBindingSource.DataSource = y.ToList();

            listBox1.DataSource = movieBindingSource;

            listBox1.DisplayMember = "Title";



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var y = from x in context.Movies
                    where x.Title.Contains(textBox1.Text)
                    select x;

            movieBindingSource.DataSource = y.ToList();

            listBox1.DataSource = movieBindingSource;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ujMovie = new Movie();

            ujMovie.Title = textBox2.Text;
            ujMovie.Description = textBox3.Text;
            ujMovie.Duration = int.Parse(textBox4.Text);
            ujMovie.Rating = textBox5.Text;

            context.Add(ujMovie);

            context.SaveChanges();

            movieBindingSource.DataSource = context.Movies.ToList();
            listBox1.DataSource = movieBindingSource;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var valasztott = listBox1.SelectedItem;
            context.Remove(valasztott);
            context.SaveChanges();
            var y = from x in context.Movies
                    where x.Title.Contains(textBox1.Text)
                    select x;

            movieBindingSource.DataSource = y.ToList();

            listBox1.DataSource = movieBindingSource;
        }
    }
}
