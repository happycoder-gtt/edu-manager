using EduManager.BLL.Services;
using EduManager.DAL.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EduManager.Pre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StudentService _studentService = new StudentService();

        public MainWindow()
        {
            InitializeComponent();
            LoadStudents();
        }


        //Tải danh sách student từ Database vào GridView
        public void LoadStudents()
        {
            dgStudents.ItemsSource = _studentService.GetAllStudents();
        }

        private Student GetStudentFromForm()
        {
            string gender = "";
            if (cboGender.SelectedItem is ComboBoxItem selectedGender)
                gender = selectedGender.Content?.ToString() ?? "";

            return new Student
            {
                StudentCode = txtStudentCode.Text,
                FullName = txtFullName.Text,
                DateOfBirth = dpDateOfBirth.SelectedDate,
                Gender = gender,
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Major = txtMajor.Text.Trim(),
                IsActive = true
            };
        }

        private void ClearForm()
        {
            txtStudentCode.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtMajor.Text = "";
            txtStudentCode.Focus();
        }

        public void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = GetStudentFromForm();
                _studentService.AddStudent(student);
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo"
                    , MessageBoxButton.OK, MessageBoxImage.Information);
                LoadStudents();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e) { }
        public void btnDelete_Click(object sender, RoutedEventArgs e) { }
        public void btnRefresh_Click(object sender, RoutedEventArgs e) { }
        public void dgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}