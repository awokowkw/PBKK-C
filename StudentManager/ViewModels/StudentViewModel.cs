using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using StudentManager.Data;
using StudentManager.Models;

namespace StudentManager.ViewModels;

public class StudentViewModel : INotifyPropertyChanged
{
    private readonly StudentRepository _repository = new();
    private List<Student> _all = new();

    public ObservableCollection<Student> Students { get; } = new();

    // Baris yang dipilih di DataGrid
    private Student? _selectedStudent;
    public Student? SelectedStudent
    {
        get => _selectedStudent;
        set
        {
            _selectedStudent = value;
            OnPropertyChanged();
            if (value != null)
            {
                // Salin ke Form supaya edit tidak langsung mengubah baris grid
                Form = new Student
                {
                    Id = value.Id,
                    NIM = value.NIM,
                    Nama = value.Nama,
                    Jurusan = value.Jurusan,
                    Gender = value.Gender,
                    Email = value.Email
                };
            }
        }
    }

    // Data yang tampil di form input
    private Student _form = new();
    public Student Form
    {
        get => _form;
        set { _form = value; OnPropertyChanged(); }
    }

    private string _searchText = "";
    public string SearchText
    {
        get => _searchText;
        set { _searchText = value; OnPropertyChanged(); }
    }

    // Statistik dihitung dari seluruh data (bukan hasil search)
    public int TotalStudents => _all.Count;
    public int TotalInformatika => _all.Count(x => x.Jurusan == "Informatika");
    public int TotalSistemInformasi => _all.Count(x => x.Jurusan == "Sistem Informasi");
    public int TotalLakiLaki => _all.Count(x => x.Gender == "Laki-laki");
    public int TotalPerempuan => _all.Count(x => x.Gender == "Perempuan");

    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ResetCommand { get; }
    public ICommand SearchCommand { get; }

    public StudentViewModel()
    {
        SaveCommand = new RelayCommand(Save);
        DeleteCommand = new RelayCommand(Delete);
        ResetCommand = new RelayCommand(Reset);
        SearchCommand = new RelayCommand(Search);
        LoadData();
    }

    private void LoadData()
    {
        _all = _repository.GetAll();
        Students.Clear();
        foreach (var student in _all)
            Students.Add(student);
        SearchText = "";
        RefreshStatistics();
    }

    private void Save()
    {
        if (string.IsNullOrWhiteSpace(Form.NIM) ||
            string.IsNullOrWhiteSpace(Form.Nama) ||
            string.IsNullOrWhiteSpace(Form.Jurusan) ||
            string.IsNullOrWhiteSpace(Form.Gender))
        {
            MessageBox.Show("NIM, Nama, Jurusan, dan Gender wajib diisi.");
            return;
        }

        if (Form.Id == 0)
            _repository.Insert(Form);
        else
            _repository.Update(Form);

        LoadData();
        Reset();
    }

    private void Delete()
    {
        if (SelectedStudent == null)
        {
            MessageBox.Show("Pilih data di tabel terlebih dahulu.");
            return;
        }

        _repository.Delete(SelectedStudent.Id);
        LoadData();
        Reset();
    }

    private void Search()
    {
        var result = string.IsNullOrWhiteSpace(SearchText)
            ? _repository.GetAll()
            : _repository.Search(SearchText);

        Students.Clear();
        foreach (var student in result)
            Students.Add(student);
    }

    private void Reset()
    {
        SelectedStudent = null;
        Form = new Student();
    }

    private void RefreshStatistics()
    {
        OnPropertyChanged(nameof(TotalStudents));
        OnPropertyChanged(nameof(TotalInformatika));
        OnPropertyChanged(nameof(TotalSistemInformasi));
        OnPropertyChanged(nameof(TotalLakiLaki));
        OnPropertyChanged(nameof(TotalPerempuan));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}