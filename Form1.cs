using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace recreep_treasure_calculator
{
    public partial class Form1 : Form
    {
        private static readonly Bitmap empty_icon = Properties.Resources.empty_png;
        private static readonly int pic_start = 10;
        private static readonly String pic_prefix = "pictureBox";
        private static readonly String label_prefix = "label";
        private static readonly String cb_prefix = "checkBox";
        private static readonly String num_prefix = "numericUpDown";
        private static readonly int text_start = 9;
        private static readonly int check_box_start = 1;
        private static readonly int numupdown_start = 1;
        private static readonly String item_icon_prefix = "item_ability_";
        private static readonly String item_text_prefix = "item_ability_text_";

        private readonly List<Treasure_info> Treasures = new List<Treasure_info>();
        private readonly SortedList<string, Item_slot> Items = new SortedList<string, Item_slot>();

        public Form1()
        {
            InitTreasure();
            InitItemSlot();
            InitializeComponent();
            InitUI();
        }

        private void InitTreasure()
        {
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "����", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��2", Properties.Resources.����ǿ��, new List<String> { "����", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "��ָ", "�Ȳ�", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��2", Properties.Resources.����ǿ��, new List<String> { "��ָ", "�Ȳ�", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "ͷ��", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("����ǿ��2", Properties.Resources.����ǿ��, new List<String> { "ͷ��", "��ָ", "����" }, 13));
            Treasures.Add(new Treasure_info("ȫ����", Properties.Resources.ȫ����ǿ��, new List<String> { "����", "��ָ", "����" }, 13, true));
            Treasures.Add(new Treasure_info("ȫ����2", Properties.Resources.ȫ����ǿ��, new List<String> { "����", "��ָ", "����" }, 13, true));
            Treasures.Add(new Treasure_info("���˶�", Properties.Resources.���˶�, new List<String> { "ͷ��", "����" }, 15, true));
            Treasures.Add(new Treasure_info("��ҿ�", Properties.Resources.��ҿ�, new List<String> { "����" }, 17, true));
            Treasures.Add(new Treasure_info("�������", Properties.Resources.�������, new List<String> { "ͷ��", "����", "����" }, 15, true));

            Treasures.Add(new Treasure_info("�����ⲫ", Properties.Resources.�����ⲫ, new List<String> { "����", "����", "����" }, 11, true));
            Treasures.Add(new Treasure_info("����ǿ��", Properties.Resources.����ǿ��, new List<String> { "����", "��ָ", "����" }, 11));
            Treasures.Add(new Treasure_info("����", Properties.Resources.����, new List<String> { "ͷ��", "�Ȳ�" }, 11));
            Treasures.Add(new Treasure_info("��Ѫ�׼�", Properties.Resources.��Ѫ�׼�, new List<String> { "����", "����", "����" }, 11, true));

            Treasures.Add(new Treasure_info("����һ��", Properties.Resources.����һ��, new List<String> { "ͷ��", "����", "����", "��ָ" }, 9));
            Treasures.Add(new Treasure_info("����һ��", Properties.Resources.����һ��, new List<String> { "ͷ��", "����", "����", "��ָ" }, 9));
            Treasures.Add(new Treasure_info("ħ����Ч", Properties.Resources.ħ����Ч, new List<String> { "����", "����", "����" }, 9));
            Treasures.Add(new Treasure_info("ԽսԽ��", Properties.Resources.ԽսԽ��, new List<String> { "����", "����", "����" }, 9));

            Treasures.Add(new Treasure_info("���㶴Ϥ", Properties.Resources.���㶴Ϥ, new List<String> { "ͷ��", "����", "����" }, 7));
            Treasures.Add(new Treasure_info("��Ӣɱ��", Properties.Resources.��Ӣɱ��, new List<String> { "ͷ��", "����", "����" }, 7));

            Treasures.Add(new Treasure_info("����ɱ��", Properties.Resources.����ɱ��, new List<String> { "����", "����" }, 5));
            Treasures.Add(new Treasure_info("��ȴ����", Properties.Resources.��ȴ����, new List<String> { "ͷ��", "��ָ", "����" }, 5));

            Treasures.Add(new Treasure_info("ħ��ԴȪ", Properties.Resources.ħ��ԴȪ, new List<String> { "ͷ��", "����", "����" }));
            Treasures.Add(new Treasure_info("�������", Properties.Resources.�������, new List<String> { "ͷ��", "����", "����" }));

            Treasures.Add(new Treasure_info("����", Properties.Resources.����, new List<String> { "����", "�Ȳ�", "����" }));
            Treasures.Add(new Treasure_info("�������", Properties.Resources.�������, new List<String> { "����", "�Ȳ�", "ͷ��", "����", "����" }));
            Treasures.Add(new Treasure_info("���ٻָ�", Properties.Resources.���ٻָ�, new List<String> { "����", "����", "����" }));
            Treasures.Add(new Treasure_info("Ƥ�����", Properties.Resources.Ƥ�����, new List<String> { "����", "����" }));
            Treasures.Add(new Treasure_info("�鶯����", Properties.Resources.�鶯����, new List<String> { "����", "�Ȳ�", "����" }));
            Treasures.Add(new Treasure_info("ħ������", Properties.Resources.ħ������, new List<String> { "����", "�Ȳ�", "ͷ��", "����", "����" }));
            Treasures.Add(new Treasure_info("����սʿ", Properties.Resources.����սʿ, new List<String> { "����", "�Ȳ�", "����" }));
            Treasures.Add(new Treasure_info("���", Properties.Resources.���, new List<String> { "����", "����", "����", "��ָ" }));
            Treasures.Add(new Treasure_info("Эͬ��ս", Properties.Resources.Эͬ��ս, new List<String> { "ͷ��", "��ָ", "����" }));
        }

        private void InitItemSlot()
        {
            Items.Add("ͷ��", new Item_slot("ͷ��", 1, 2));
            Items.Add("����", new Item_slot("����", 2, 2));
            Items.Add("����", new Item_slot("����", 3, 2));
            Items.Add("����", new Item_slot("����", 4, 2));
            Items.Add("�Ȳ�", new Item_slot("�Ȳ�", 5, 2));
            Items.Add("����", new Item_slot("����", 6, 2));
            Items.Add("��ָ", new Item_slot("��ָ", 7, 4));
        }

        private void InitUI()
        {
            int cur = 0;
            foreach (var treasure in Treasures)
            {
                Control[] pic = Controls.Find(pic_prefix + (pic_start + cur), true);
                Control[] text = Controls.Find(label_prefix + (text_start + cur), true);
                Control[] cb = Controls.Find(cb_prefix + (check_box_start + cur), true);
                Control[] nud = Controls.Find(num_prefix + (numupdown_start + cur), true);
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
            SortedList<string, List<String>> item_info = new SortedList<string, List<String>>();
            //���Ƴ���ǰ��
            foreach (var item in Items.Keys)
            {
                for (var i = 1; i <= Items[item].slots; i++)
                {
                    Control[] icon = Controls.Find(item_icon_prefix + Items[item].ui_id + '_' + i, true);
                    if (icon.Length > 0) { icon[0].BackgroundImage = empty_icon; }
                    Control[] text = Controls.Find(item_text_prefix + Items[item].ui_id + '_' + i, true);
                    if (text.Length > 0) { text[0].Visible = false; }
                }
                item_info.Add(Items[item].name, new List<String>());
            }

            List<Treasure_info> temp_info = new List<Treasure_info>();
            foreach (var treasure in Treasures)
            {
                if (treasure.default_enable) { temp_info.Add(treasure); }
            }
            temp_info.Sort((a, b) =>
            {
                return b.default_priority - a.default_priority;
            });

            foreach (var treasure in temp_info)
            {
                String t_name = treasure.name;
                List<String> t_slots = treasure.slots;
                foreach (var slot_name in t_slots)
                {
                    if (item_info[slot_name].Count < Items[slot_name].slots)
                    {
                        item_info[slot_name].Add(t_name);
                        Control[] icon = Controls.Find(item_icon_prefix + Items[slot_name].ui_id + '_' + item_info[slot_name].Count, true);
                        if (icon.Length > 0) { icon[0].BackgroundImage = treasure.icon; }
                        Control[] text = Controls.Find(item_text_prefix + Items[slot_name].ui_id + '_' + item_info[slot_name].Count, true);
                        if (text.Length > 0) { text[0].Visible = true; text[0].Text = t_name; }
                        break;
                    }
                }
            }
        }

        private void label41_Paint(object sender, PaintEventArgs e)
        {
            ((Label)sender).Parent = pictureBox1;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox trigger = (CheckBox)sender;
            int treasure_id = int.Parse(trigger.Name.Replace(cb_prefix, "")) - 1;
            Console.WriteLine(String.Format("{0:s} -> {1:s}", Treasures[treasure_id].name, trigger.Checked));
            Treasures[treasure_id].default_enable = trigger.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown trigger = (NumericUpDown)sender;
            int treasure_id = int.Parse(trigger.Name.Replace(num_prefix, "")) - 1;
            Console.WriteLine(String.Format("{0:s} -> {1:n}", Treasures[treasure_id].name, trigger.Value));
            Treasures[treasure_id].default_priority = Convert.ToInt32(trigger.Value);
        }
    }
}
class Treasure_info
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

class Item_slot
{
    public String name;
    public int ui_id;
    public int slots;

    public Item_slot(string a, int b, int c)
    {
        name = a; ui_id = b; slots = c;
    }
}
