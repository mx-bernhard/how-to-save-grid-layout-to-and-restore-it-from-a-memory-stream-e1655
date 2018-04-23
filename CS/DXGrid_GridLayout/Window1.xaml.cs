using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace DXGrid_GridLayout {
    public partial class Window1 : Window {
        private string fileName = "gridLayout.xml";
        static Window1() {
            IsLayoutSavedProperty = DependencyProperty.Register("IsLayoutSaved", 
                typeof(bool), typeof(Window1));
        }
        public Window1() {
            InitializeComponent();
            IsLayoutSaved = System.IO.File.Exists(fileName);
            grid.DataSource = IssueList.GetData();
        }
        public static readonly DependencyProperty IsLayoutSavedProperty;
        public bool IsLayoutSaved {
            get { return (bool)GetValue(Window1.IsLayoutSavedProperty); }
            set { SetValue(Window1.IsLayoutSavedProperty, value); }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            grid.SaveLayoutToXml(fileName);
            IsLayoutSaved = true;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e) {
            grid.RestoreLayoutFromXml(fileName);
        }
    }
    public class IssueList {
        static public List<IssueDataObject> GetData() {
            List<IssueDataObject> data = new List<IssueDataObject>();
            data.Add(new IssueDataObject() { IssueName = "Transaction History",
                IssueType = "Bug", IsPrivate = true });
            data.Add(new IssueDataObject() { IssueName = "Ledger: Inconsistency",
                IssueType = "Bug", IsPrivate = false });
            data.Add(new IssueDataObject() { IssueName = "Data Import",
                IssueType = "Request", IsPrivate = false });
            data.Add(new IssueDataObject() { IssueName = "Data Archiving",
                IssueType = "Request", IsPrivate = true });
            return data;
        }
    }

    public class IssueDataObject {
        public string IssueName { get; set; }
        public string IssueType { get; set; }
        public bool IsPrivate { get; set; }
    }
}
