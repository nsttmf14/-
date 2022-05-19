using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дополнительное__задание
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Image> images = new List<Image>();
        Random rnd = new Random();
        string[] person;

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private void button1_Click(object sender, EventArgs e)
        {
            logger.Trace("Загружаются студенты 09-121 группы");
            LogRTB.Text += "Загружаются студенты 09-121 группы \n";

            TreeView.Nodes[0].Nodes.Add(new TreeNode("Настя Тимофеева"));
            TreeView.Nodes[0].Nodes.Add(new TreeNode("Карим Муллаянов"));
            TreeView.Nodes[0].Nodes.Add(new TreeNode("Саша Кузнецов"));
            TreeView.Nodes[0].Nodes.Add(new TreeNode("Аделя Назмиева"));
            TreeView.Nodes[0].Nodes.Add(new TreeNode("Ксюша Макарова"));

            logger.Trace("Загружаются студенты 09-122 группы");
            LogRTB.Text += "Загружаются студенты 09-122 группы \n";

            TreeView.Nodes[1].Nodes.Add(new TreeNode("Даниль Юринов"));
            TreeView.Nodes[1].Nodes.Add(new TreeNode("Марьям Ахметсафина"));
            TreeView.Nodes[1].Nodes.Add(new TreeNode("Лена Конышева"));
            TreeView.Nodes[1].Nodes.Add(new TreeNode("Кирилл Романов"));
            TreeView.Nodes[1].Nodes.Add(new TreeNode("Алмаз Зиастинов"));
        }
        private void RecastImages()
        {
            LoadList();

            logger.Trace("Распределение картинок");
            LogRTB.Text += "Распределение картинок \n";

            int n = rnd.Next(5);
            pictureBox1.Image = images[n];
            images.RemoveAt(n);

            n = rnd.Next(4);
            pictureBox2.Image = images[n];
            images.RemoveAt(n);

            n = rnd.Next(3);
            pictureBox3.Image = images[n];
            images.RemoveAt(n);

            n = rnd.Next(2);
            pictureBox4.Image = images[n];
            images.RemoveAt(n);

            n = rnd.Next(1);
            pictureBox5.Image = images[n];
            images.RemoveAt(n);

            logger.Trace("Очистка листа");
            LogRTB.Text += "Очистка листа \n";

            images.Clear();
        }

        private void LoadList()
        {
            logger.Trace("Загрузка картинок в лист");
            LogRTB.Text += "Загрузка картинок в лист \n";

            images.Add(Properties.Resources._1);
            images.Add(Properties.Resources._2);
            images.Add(Properties.Resources._3);
            images.Add(Properties.Resources._4);
            images.Add(Properties.Resources._5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            logger.Trace("Перераспределение картинок началось");
            LogRTB.Text += "Перераспределение картинок началось \n";
            RecastImages();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                logger.Trace("Создание и заполнение доп.формы");
                LogRTB.Text += "Создание и заполнение доп.формы \n";

                AdditionlForm adForm = new AdditionlForm();

                for (int i = 0; i < 5; i++)
                {
                    person = TreeView.SelectedNode.Nodes[i].Text.Split();
                    adForm.Data.Rows.Add(person[0], person[1]);
                }

                adForm.Group.Text = TreeView.SelectedNode.Text;

                logger.Trace("Показ формы");
                LogRTB.Text += "Показ формы \n";

                adForm.Show();
            }
            catch
            {
                logger.Error("Группа не была выбрана");
                ErrorRTB.Text += "Группа не была выбрана \n";
                MessageBox.Show("Сначала выберите группу", "Ошибка");
            }
        }
    }
}
