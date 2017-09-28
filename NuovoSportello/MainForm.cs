using CedacriData.DS;
using CedacriData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuovoSportello
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        ICedacriDataSource ds;
        public MainForm()
        {
            InitializeComponent();

            //CedacriInMemoryDataSource ds = new CedacriInMemoryDataSource();
            //CedacriWebServiceDataSource ds = new CedacriWebServiceDataSource();

            ds = new CedacriWebServiceDataSource();

            List<Client> clientList = ds.GetAllClients();
            foreach (Client cli in clientList)
            {
                this.listBox1.Items.Add(cli.FirstName + " " + cli.LastName);
            }
        }
    }
}
