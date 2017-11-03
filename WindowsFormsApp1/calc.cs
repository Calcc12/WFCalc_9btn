using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class calc : Form
    {
        public calc()
        {
            InitializeComponent();
        }
        int fNum = 0;
        int sNum = 0;
        char op = ' ';
        private void btn1_Click(object sender, EventArgs e)
        {
            str.Text += (sender as Button).Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            fNum =int.Parse(str.Text);
            op = char.Parse((sender as Button).Text);
            str.Text = "";
        }

        private void res_Click(object sender, EventArgs e)
        {
            sNum = int.Parse(str.Text);
            str.Text = Calc(fNum, sNum, op).ToString();
        }
        public int Calc(int fNum, int sNum, char op)
        {
            int result = 0;
            switch (op)
            {
                case '+':
                    result = fNum + sNum;
                    break;
                case '-':
                    result = fNum - sNum;
                    break;
                case '*':
                    result = fNum * sNum;
                    break;
                case '/':
                    result = fNum / sNum;
                    break;
            }
            return result;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            str.Clear();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            str.Text = str.Text.Remove(str.Text.Length - 1, 1);
        }

        private void Str_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
