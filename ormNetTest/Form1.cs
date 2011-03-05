using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ormNetTest
{
    public partial class Form1 : Form
    {
        BuildWolfSandboxBiz.DataManager m_dataManager = 
            new BuildWolfSandboxBiz.DataManager(@"Data Source=N136\SQLEXPRESS;User ID=mason;");
            
        
        public Form1()
        {
            InitializeComponent();
        }

        private void idc_addComment_Click(object sender, EventArgs e)
        {
            BuildWolfSandboxBiz.Comments newComment = m_dataManager.New
            m_dataManager.GetCommentsCollection().Add(c);
            newComment.CommentText = "this is text";
            newComment.CommentTime = DateTime.Now;
            

        }
    }
}