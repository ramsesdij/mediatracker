using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlurayTracker
{
    public partial class Form1 : Form
    {
        private DialogHelper dialogHelper = new DialogHelper();      
        private List<Movie> movies = new List<Movie>();
        private List<Movie> filteredMovies = new List<Movie>();
        private Loader loader;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = comboBox1.FindStringExact("DVD");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            progressBar1.Hide();
        }

        protected void ResetFields()
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.Text = string.Empty;
            movieAvailable.Checked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            if (textBox2.Text != string.Empty && textBox3.Text != string.Empty && comboBox1.Text != string.Empty)
            {
                MessageBox.Show("Save changes before leaving?");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && comboBox1.Text != string.Empty)
            {
                Movie movie = new Movie(textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text, movieAvailable.Checked);               
                dataGridView1.Rows.Add(movie.Title, movie.Year, movie.Format, movie.Country, movie.Available);
                this.movies.Add(movie);
                this.ResetFields();
            } else
            {
                MessageBox.Show("One or more fields are missing");
            }
        }

        /// <summary>
        /// Load movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            List<Movie> movies = this.dialogHelper.LoadFile();
            this.loader = new Loader(progressBar1);
            this.loader.SetLoader(movies);

            if (movies != null)
            {
                foreach (Movie movie in movies)
                {
                    this.movies.Add(movie);
                    dataGridView1.Rows.Add(movie.Title, movie.Year, movie.Format, movie.Country, movie.Available);
                    this.loader.IncrementLoader();
                }              
            }          
        }

        /// <summary>
        /// Save movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.dialogHelper.SaveFile(this.movies);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            if (textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && comboBox1.Text != string.Empty)
            {
                MessageBox.Show("Save changes before leaving?");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.filteredMovies = this.movies.Where(movie => movie.Title.Contains(textBox1.Text.ToString())).ToList();
            this.BindList(this.filteredMovies);           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        protected void BindList(List<Movie> movies)
        {
            var bindingList = new BindingList<Movie>(movies);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }
    }
}
