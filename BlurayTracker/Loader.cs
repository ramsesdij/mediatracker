using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlurayTracker
{
    public class Loader
    {
        private int moviesLength = 0;   
        private ProgressBar progressBar;

        public Loader(ProgressBar progressBar)
        {
            this.progressBar = progressBar;
        }

        private void Reset()
        {
            this.progressBar.Value = this.progressBar.Maximum;
            this.moviesLength = 0;
       
        }

        public void SetLoader(List<Movie> movies)
        {
            this.Reset();
            this.moviesLength = movies.Count;
            this.progressBar.Maximum = this.moviesLength;
           
        }

        public void IncrementLoader()
        {
            if (this.progressBar.Value != this.moviesLength)
            {
                this.progressBar.Value++;               
            } else
            {
                this.progressBar.Value = this.progressBar.Maximum;
            }                     
        }
    }
}
