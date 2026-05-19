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
        private int _studentId = 0;

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
                StudentId = _studentId,
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
            _studentId = 0;
            txtStudentCode.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtMajor.Text = "";
            txtStudentCode.IsEnabled = true;
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

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_studentId == 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên trong danh sách để sửa.");
                    return;
                }
                Student student = GetStudentFromForm();
                _studentService.UpdateStudent(student);
                LoadStudents();
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_studentId == 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                    return;
                }
                MessageBoxResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?",
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (confirm == MessageBoxResult.Yes)
                {
                    _studentService.DeleteStudent(_studentId);
                    LoadStudents();
                    ClearForm();
                    MessageBox.Show("Xóa sinh viên thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void btnRefresh_Click(object sender, RoutedEventArgs e) {
            LoadStudents();
            ClearForm();
        }
        public void dgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgStudents.SelectedItem is not Student student)
                return;
            _studentId = student.StudentId;
            txtStudentCode.Text = student.StudentCode;
            txtFullName.Text = student.FullName;
            dpDateOfBirth.SelectedDate = student.DateOfBirth;
            txtEmail.Text = student.Email;
            txtPhone.Text = student.Phone;
            txtMajor.Text = student.Major;
            if (student.Gender == "Nam")
                cboGender.SelectedIndex = 0;
            else if (student.Gender == "Nữ")
                cboGender.SelectedIndex = 1;
            else
                cboGender.SelectedIndex = -1;
            txtStudentCode.IsEnabled = false;

        }
    }
}