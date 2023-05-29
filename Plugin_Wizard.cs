using System;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        DialogResult result = MessageBox.Show(
            "The operation you are about to perform can be dangerous. Are you sure you want to proceed?",
            "Warning!",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        // If the user clicks "Yes", the result will be DialogResult.Yes.
        // You can then signal to the main application to proceed.
        if (result == DialogResult.Yes)
        {
            Environment.Exit(1); // Exit with code 1 to signal "Yes"
        }
        else
        {
            Environment.Exit(0); // Exit with code 0 to signal "No" or any other situation
        }
    }
}
