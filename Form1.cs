using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMware.Vim;
using System.Collections.Specialized;


namespace Vmware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameValueCollection filter = new NameValueCollection();
            //filter.Add("Runtime.PowerState", "PoweredOff");
            //filter.Add("name", "^Test");


            VimClient client = new VimClient();
            client.Connect("https://10.152.34.210/sdk/vimService"); // /sdk
            client.Login("root", "Password");
            IList<EntityViewBase> vmList = client.FindEntityViews(typeof(VirtualMachine), null, filter, null);

            // Power off the virtual machines.
            foreach (VirtualMachine vm in vmList)
            {
                // Refresh the state of each view.
                vm.UpdateViewData();
                if (vm.Runtime.PowerState == VirtualMachinePowerState.poweredOn)
                {
                    //vm.PowerOffVM();
                    //Console.WriteLine("Stopped virtual machine: {0}", vm.Name);
                    listBox1.Items.Add(vm.Name);
                    //listBox1.Items.Add(vm.)
                    
                }
            }
            client.Disconnect();
        }
    }
}
