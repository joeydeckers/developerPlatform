using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobOffer.Business;

namespace JobOfferTest.View
{
    public partial class Form1 : Form
    {
        private List<JobOfferItem> jobOffers; 

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            jobOffers = JobOfferItem.GetAllJobOffers();

            foreach(var jobOffer in jobOffers)
            {
                listBox1.Items.Add(jobOffer.ToString());
            }
        }
    }
}
