using System.Collections;
using System.IO;
using System.Reflection;

namespace recreep_treasure_calculator
{
    public partial class Form1 : Form
    {
        private struct Treasure_info
        {
            public String name;
            public Bitmap icon;
            public int default_priority;
            public Boolean default_enable;
            public List<String> slots;

            public Treasure_info(String a, Bitmap b, List<String> i, int c, Boolean d)
            {
                name = a;
                icon = b;
                default_priority = c;
                default_enable = d;
                slots = i;
            }
            public Treasure_info(String a, Bitmap b, List<String> i, int c)
            {
                name = a;
                icon = b;
                default_priority = c;
                default_enable = false;
                slots = i;
            }
            public Treasure_info(String a, Bitmap b, List<String> i)
            {
                name = a;
                icon = b;
                default_priority = 0;
                default_enable = false;
                slots = i;
            }
        }

        private List<Treasure_info> Treasures = new List<Treasure_info>();

        public Form1()
        {
            InitTreasure();
            InitializeComponent();
            InitUI();
        }

        private void InitTreasure()
        {
            Treasures.Add(new Treasure_info("����", Properties.Resources.����,  new List<String>{ "����","�Ȳ�","����"}));
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "����", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��2", Properties.Resources.����ǿ��, new List<String> { "����", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "��ָ", "�Ȳ�", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��2", Properties.Resources.����ǿ��, new List<String> { "��ָ", "�Ȳ�", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "ͷ��", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��2", Properties.Resources.����ǿ��, new List<String> { "ͷ��", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("ȫ����", Properties.Resources.ȫ����ǿ��, new List<String> { "����", "��ָ", "����" }, 13, true));
            Treasures.Add(new Treasure_info("ȫ����2", Properties.Resources.ȫ����ǿ��, new List<String> { "����", "��ָ", "����" }, 13, true));
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "����", "��ָ", "����" }, 11));
            Treasures.Add(new Treasure_info("����һ��", Properties.Resources.����һ��, new List<String> { "ͷ��", "����", "����", "��ָ" }, 9));
            Treasures.Add(new Treasure_info("����һ��", Properties.Resources.����һ��, new List<String> { "ͷ��", "����", "����", "��ָ" }, 9));
            Treasures.Add(new Treasure_info("�������", Properties.Resources.�������, new List<String> { "����", "�Ȳ�", "ͷ��", "����", "����" }));
            Treasures.Add(new Treasure_info("���ٻָ�", Properties.Resources.���ٻָ�, new List<String> { "����", "����", "����" }));
            Treasures.Add(new Treasure_info("ħ��ԴȪ", Properties.Resources.ħ��ԴȪ, new List<String> { "ͷ��", "����", "����" }));
            Treasures.Add(new Treasure_info("Ƥ�����", Properties.Resources.Ƥ�����, new List<String> { "����", "����" }));
            Treasures.Add(new Treasure_info("�鶯����", Properties.Resources.�鶯����, new List<String> { "����", "�Ȳ�", "����" }));
            Treasures.Add(new Treasure_info("����", Properties.Resources.����, new List<String> { "ͷ��", "�Ȳ�" }, 11));
            Treasures.Add(new Treasure_info("�������", Properties.Resources.�������, new List<String> { "ͷ��", "����", "����" }, 15, true));
            Treasures.Add(new Treasure_info("����ɱ��", Properties.Resources.����ɱ��, new List<String> { "����", "����" }, 5));
            Treasures.Add(new Treasure_info("�����ⲫ", Properties.Resources.�����ⲫ, new List<String> { "����", "����", "����" }, 11, true));
            Treasures.Add(new Treasure_info("��ҿ�", Properties.Resources.��ҿ�, new List<String> { "����" }, 17, true));
            Treasures.Add(new Treasure_info("��ȴ����", Properties.Resources.��ȴ����, new List<String> { "ͷ��", "��ָ", "����" }, 5));
            Treasures.Add(new Treasure_info("ħ������", Properties.Resources.ħ������, new List<String> { "����", "�Ȳ�", "ͷ��", "����", "����" }));
            Treasures.Add(new Treasure_info("���㶴Ϥ", Properties.Resources.���㶴Ϥ, new List<String> { "ͷ��", "����", "����" }, 7));
            Treasures.Add(new Treasure_info("�������", Properties.Resources.�������, new List<String> { "ͷ��", "����", "����" }));
            Treasures.Add(new Treasure_info("���˶�", Properties.Resources.���˶�, new List<String> { "ͷ��", "����" }, 15, true));
            Treasures.Add(new Treasure_info("��Ӣɱ��", Properties.Resources.��Ӣɱ��, new List<String> { "ͷ��", "����", "����" }, 7));
            Treasures.Add(new Treasure_info("����սʿ", Properties.Resources.����սʿ, new List<String> { "����", "�Ȳ�", "����" }));
            Treasures.Add(new Treasure_info("��Ѫ�׼�", Properties.Resources.��Ѫ�׼�, new List<String> { "����", "����", "����" }, 11, true));
            Treasures.Add(new Treasure_info("ħ����Ч", Properties.Resources.ħ����Ч, new List<String> { "����", "����", "����" }, 9));
            Treasures.Add(new Treasure_info("ԽսԽ��", Properties.Resources.ԽսԽ��, new List<String> { "����", "����", "����" }, 9));
            Treasures.Add(new Treasure_info("���", Properties.Resources.���, new List<String> { "����", "����", "����", "��ָ" }));
            Treasures.Add(new Treasure_info("Эͬ��ս", Properties.Resources.Эͬ��ս, new List<String> { "ͷ��", "��ָ", "����" }));
        }

        private void InitUI()
        {
            int pic_start = 10;
            int text_start = 9;
            int check_box_start = 1;
            int numupdown_start = 1;
            int cur = 0;
            foreach (var treasure in Treasures)
            {
                Control[] pic = this.Controls.Find("pictureBox" + (pic_start + cur), true);
                Control[] text = this.Controls.Find("label" + (text_start + cur), true);
                Control[] cb = this.Controls.Find("checkBox" + (check_box_start + cur), true);
                Control[] nud = this.Controls.Find("numericUpDown" + (numupdown_start + cur), true);
                if (pic.Length > 0)
                {
                    pic[0].BackgroundImage = treasure.icon;
                    pic[0].Visible = true;
                }
                if (text.Length > 0)
                {
                    text[0].Text = treasure.name;
                    text[0].Visible = true;
                }
                if (cb.Length > 0)
                {
                    if (treasure.default_enable)
                    {
                        ((CheckBox)cb[0]).Checked = true;
                    }
                    cb[0].Visible = true;
                }
                if (nud.Length > 0)
                {
                    ((NumericUpDown)nud[0]).Value = treasure.default_priority;
                    nud[0].Visible = true;
                }
                cur++;
            }
        }

        private void _ShowTreasureAbilitySelectTooltip(object sender, EventArgs e)
        {
            ToolTip new_tooltip = new()
            {
                AutoPopDelay = 0,
                InitialDelay = 0,
                ReshowDelay = 0,
                ShowAlways = true
            };
            new_tooltip.SetToolTip((PictureBox)sender, "[��δʵ��]�����ѡ�������е��䱦���ܣ����ս�����ϵͳ����");
        }

        private void checkBox_Paint(object sender, PaintEventArgs e)
        {
            ((CheckBox)sender).Parent = pictureBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}