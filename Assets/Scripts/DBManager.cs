using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class DBManager : MonoBehaviour {

    private string connectionString;

    private List<Frases> frases = new List<Frases>();

    public GameObject frasesPrefab;
    public Transform frasesParent;
    public Text enterPhrase;

    // Use this for initialization
    void Start()
    {
        /*string filepath = Application.dataPath + "/frasesDB.sqlite";

        if (!File.Exists(filepath))
        {
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/frasesDB.sqlite");

            while (!loadDB.isDone) { }

            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        connectionString = "URI=file:" + filepath;*/
    }

    private void GetFrases()
    {
        frases.Clear();

        //creating an sqlite connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //open connection to the database
            dbConnection.Open();

            //creating a db connection
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //string for sql query
                string sqlQuery = "SELECT * FROM Frases";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetInt32(0));
                        frases.Add( new Frases (reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4) ) );
                    }

                    //closing connection to the database
                    dbConnection.Close();
                    reader.Close();

                }
            }
        }

        frases.Sort();
    }

    private void GetOwnFrases()
    {
        frases.Clear();

        //creating an sqlite connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //open connection to the database
            dbConnection.Open();

            //creating a db connection
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //string for sql query
                string sqlQuery = "SELECT * FROM Frases WHERE titpo = 1;";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {  
                        frases.Add(new Frases(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
                    }

                    //closing connection to the database
                    dbConnection.Close();
                    reader.Close();

                }
            }
        }

        frases.Sort();
    }

    public void AddFrases()
    {
        if (enterPhrase.text != "")
        {
            GetFrases();

            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    int i = frases[0].id + 1;
                    Debug.Log("new number: " + i);
                    Debug.Log("old number: " + frases.Count + "+ 4");
                    string sqlQuery = String.Format(" INSERT INTO Frases(id,textSP,textEN,categoria,titpo) VALUES({0},\"{1}\",\"{2}\",1,1)", i, enterPhrase.text, enterPhrase.text);
                    dbCmd.CommandText = sqlQuery;

                    Debug.Log(frases.Count);
                    dbCmd.ExecuteScalar();

                    dbConnection.Close();

                    enterPhrase.text = "";
                }
            }
        }
    }

    private void deleteFrases()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM Frases WHERE id = \"{0}\"",216);
                dbCmd.CommandText = sqlQuery;

                dbCmd.ExecuteScalar();

                dbConnection.Close();

            }
        }
    }

    public void ShowFrases()
    {
        GetFrases();

        for (int i = 0; i < frases.Count ; i++ )
        {
            GameObject tempObject = Instantiate(frasesPrefab);
            Frases tempFrases = frases[i];

            tempObject.GetComponent<FrasesScript>().SetText(tempFrases.textEN);

            tempObject.transform.SetParent(frasesParent);
            float num = (float) i * 100;
            num = num + 1.9f;
            tempObject.GetComponent<RectTransform>().localPosition = new Vector3(0.0f,-num,0);
        }
    }

    public void ShowOwnFrases()
    {
        GetOwnFrases();

        for (int i = 0; i < frases.Count; i++)
        {
            GameObject tempObject = Instantiate(frasesPrefab);
            Frases tempFrases = frases[i];

            tempObject.GetComponent<FrasesScript>().SetText(tempFrases.textEN);

            tempObject.transform.SetParent(frasesParent);
            float num = (float)i * 100;
            num = num + 1.9f;
            tempObject.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, -num, 0);
        }
    }

}
