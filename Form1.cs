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
            Treasures.Add(new Treasure_info("力量强化", Properties.Resources.力量强化, new List<String> { "手腕", "戒指", "挂饰" }, 13));
            Treasures.Add(new Treasure_info("力量强化2", Properties.Resources.力量强化, new List<String> { "手腕", "戒指", "挂饰" }, 13));
            Treasures.Add(new Treasure_info("敏捷强化", Properties.Resources.敏捷强化, new List<String> { "戒指", "腿部", "挂饰" }, 13));
            Treasures.Add(new Treasure_info("敏捷强化2", Properties.Resources.敏捷强化, new List<String> { "戒指", "腿部", "挂饰" }, 13));
            Treasures.Add(new Treasure_info("智力强化", Properties.Resources.智力强化, new List<String> { "头部", "戒指", "挂饰" }, 13));
            Treasures.Add(new Treasure_info("智力强化2", Properties.Resources.智力强化, new List<String> { "头部", "戒指", "挂饰" }, 13));
            Treasures.Add(new Treasure_info("全属性", Properties.Resources.全属性强化, new List<String> { "下身", "戒指", "挂饰" }, 13, true));
            Treasures.Add(new Treasure_info("全属性2", Properties.Resources.全属性强化, new List<String> { "下身", "戒指", "挂饰" }, 13, true));
            Treasures.Add(new Treasure_info("幸运儿", Properties.Resources.幸运儿, new List<String> { "头部", "挂饰" }, 15, true));
            Treasures.Add(new Treasure_info("金币狂潮", Properties.Resources.金币狂潮, new List<String> { "挂饰" }, 17, true));
            Treasures.Add(new Treasure_info("宝库达人", Properties.Resources.宝库达人, new List<String> { "头部", "手腕", "挂饰" }, 15, true));

            Treasures.Add(new Treasure_info("近身肉搏", Properties.Resources.近身肉搏, new List<String> { "下身", "上身", "挂饰" }, 11, true));
            Treasures.Add(new Treasure_info("攻速强化", Properties.Resources.攻速强化, new List<String> { "手腕", "戒指", "挂饰" }, 11));
            Treasures.Add(new Treasure_info("凝神", Properties.Resources.凝神, new List<String> { "头部", "腿部" }, 11));
            Treasures.Add(new Treasure_info("鲜血献祭", Properties.Resources.鲜血献祭, new List<String> { "下身", "上身", "挂饰" }, 11, true));

            Treasures.Add(new Treasure_info("致命一击", Properties.Resources.致命一击, new List<String> { "头部", "手腕", "挂饰", "戒指" }, 9));
            Treasures.Add(new Treasure_info("会心一击", Properties.Resources.会心一击, new List<String> { "头部", "手腕", "挂饰", "戒指" }, 9));
            Treasures.Add(new Treasure_info("魔力增效", Properties.Resources.魔力增效, new List<String> { "下身", "上身", "挂饰" }, 9));
            Treasures.Add(new Treasure_info("越战越勇", Properties.Resources.越战越勇, new List<String> { "下身", "上身", "挂饰" }, 9));

            Treasures.Add(new Treasure_info("弱点洞悉", Properties.Resources.弱点洞悉, new List<String> { "头部", "手腕", "挂饰" }, 7));
            Treasures.Add(new Treasure_info("精英杀手", Properties.Resources.精英杀手, new List<String> { "头部", "手腕", "挂饰" }, 7));

            Treasures.Add(new Treasure_info("中立杀手", Properties.Resources.中立杀手, new List<String> { "手腕", "挂饰" }, 5));
            Treasures.Add(new Treasure_info("冷却加速", Properties.Resources.冷却加速, new List<String> { "头部", "戒指", "挂饰" }, 5));

            Treasures.Add(new Treasure_info("魔力源泉", Properties.Resources.魔力源泉, new List<String> { "头部", "手腕", "挂饰" }));
            Treasures.Add(new Treasure_info("射击达人", Properties.Resources.射击达人, new List<String> { "头部", "手腕", "挂饰" }));

            Treasures.Add(new Treasure_info("灵巧", Properties.Resources.灵巧, new List<String> { "下身", "腿部", "挂饰" }));
            Treasures.Add(new Treasure_info("物理防御", Properties.Resources.物理防御, new List<String> { "下身", "腿部", "头部", "手腕", "上身" }));
            Treasures.Add(new Treasure_info("快速恢复", Properties.Resources.快速恢复, new List<String> { "下身", "上身", "挂饰" }));
            Treasures.Add(new Treasure_info("皮糙肉厚", Properties.Resources.皮糙肉厚, new List<String> { "下身", "上身" }));
            Treasures.Add(new Treasure_info("灵动闪躲", Properties.Resources.灵动闪躲, new List<String> { "下身", "腿部", "上身" }));
            Treasures.Add(new Treasure_info("魔法防御", Properties.Resources.魔法防御, new List<String> { "下身", "腿部", "头部", "手腕", "上身" }));
            Treasures.Add(new Treasure_info("绝境战士", Properties.Resources.绝境战士, new List<String> { "下身", "腿部", "上身" }));
            Treasures.Add(new Treasure_info("坚盾", Properties.Resources.坚盾, new List<String> { "下身", "下身", "挂饰", "戒指" }));
            Treasures.Add(new Treasure_info("协同作战", Properties.Resources.协同作战, new List<String> { "头部", "戒指", "挂饰" }));
        }

        private void InitItemSlot()
        {
            Items.Add("头部", new Item_slot("头部", 1, 2));
            Items.Add("上身", new Item_slot("上身", 2, 2));
            Items.Add("手腕", new Item_slot("手腕", 3, 2));
            Items.Add("下身", new Item_slot("下身", 4, 2));
            Items.Add("腿部", new Item_slot("腿部", 5, 2));
            Items.Add("挂饰", new Item_slot("挂饰", 6, 2));
            Items.Add("戒指", new Item_slot("戒指", 7, 4));
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
            new_tooltip.SetToolTip((PictureBox)sender, "[暂未实现]点击可选择你现有的珍宝技能，留空将交由系统分配");
        }

        private void checkBox_Paint(object sender, PaintEventArgs e)
        {
            ((CheckBox)sender).Parent = pictureBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortedList<string, List<String>> item_info = new SortedList<string, List<String>>();
            //先移除以前的
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
