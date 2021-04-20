using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NoteApp.Entities;

namespace NoteApp.DataAccess
{
    public class NotesRepository
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NotesDb;Integrated Security=True;Connect Timeout=5;";

        public List<Note> GetAllNotes()
        {
            List<Note> notes = new();

            string sql = "SELECT * FROM Notes;";
            SqlConnection sqlConnection = new(connectionString);
            SqlCommand command = new(sql, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                int id = (int)reader["NoteId"];
                string title = (string)reader["Title"];
                string text = (string)reader["Text"];

                Note note = new() { NoteId = id, Title = title, Text = text };
                notes.Add(note);
            }

            sqlConnection.Close();

            return notes;
        }
    }
}
