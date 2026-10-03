using Microsoft.Data.SqlClient;
using StudentManager.Models;

namespace StudentManager.Data;

public class StudentRepository
{
    private readonly string connectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;";

    private const string SelectColumns = "SELECT Id, NIM, Nama, Jurusan, Gender, Email FROM Students ";

    // READ
    public List<Student> GetAll()
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand(SelectColumns + "ORDER BY Id DESC", connection);
        connection.Open();
        return ReadStudents(command);
    }

    // SEARCH
    public List<Student> Search(string keyword)
    {
        using var connection = new SqlConnection(connectionString);
        string sql = SelectColumns +
            "WHERE NIM LIKE @Keyword OR Nama LIKE @Keyword OR Jurusan LIKE @Keyword " +
            "ORDER BY Id DESC";
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
        connection.Open();
        return ReadStudents(command);
    }

    // INSERT
    public void Insert(Student s)
    {
        using var connection = new SqlConnection(connectionString);
        string sql = "INSERT INTO Students (NIM, Nama, Jurusan, Gender, Email) " +
                     "VALUES (@NIM, @Nama, @Jurusan, @Gender, @Email)";
        using var command = new SqlCommand(sql, connection);
        AddParameters(command, s);
        connection.Open();
        command.ExecuteNonQuery();
    }

    // UPDATE
    public void Update(Student s)
    {
        using var connection = new SqlConnection(connectionString);
        string sql = "UPDATE Students SET NIM=@NIM, Nama=@Nama, Jurusan=@Jurusan, " +
                     "Gender=@Gender, Email=@Email WHERE Id=@Id";
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", s.Id);
        AddParameters(command, s);
        connection.Open();
        command.ExecuteNonQuery();
    }

    // DELETE
    public void Delete(int id)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand("DELETE FROM Students WHERE Id=@Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();
        command.ExecuteNonQuery();
    }

    private static void AddParameters(SqlCommand command, Student s)
    {
        command.Parameters.AddWithValue("@NIM", s.NIM);
        command.Parameters.AddWithValue("@Nama", s.Nama);
        command.Parameters.AddWithValue("@Jurusan", s.Jurusan);
        command.Parameters.AddWithValue("@Gender", s.Gender);
        command.Parameters.AddWithValue("@Email", s.Email);
    }

    private static List<Student> ReadStudents(SqlCommand command)
    {
        var students = new List<Student>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            students.Add(new Student
            {
                Id = Convert.ToInt32(reader["Id"]),
                NIM = reader["NIM"].ToString()!,
                Nama = reader["Nama"].ToString()!,
                Jurusan = reader["Jurusan"].ToString()!,
                Gender = reader["Gender"].ToString()!,
                Email = reader["Email"].ToString()!
            });
        }
        return students;
    }
}