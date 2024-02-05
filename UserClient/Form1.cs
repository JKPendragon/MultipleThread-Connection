namespace UserClient
{
    public partial class getData : Form
    {
        public getData()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetupSeverData s = new SetupSeverData();
            s.Show();
        }
    }
}
