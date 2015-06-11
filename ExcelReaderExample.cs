using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public class ExcelReaderExample : MonoBehaviour {

	public string filepath = "Assets/GameSheet.xml";

	// Use this for initialization
	void Start () {
		Movie movie = new Movie ();
		movie.Title = "Starship Troopers";
		movie.ReleaseDate = DateTime.Parse ("11/7/1997");
		movie.Rating = 6;

		Movie movie2 = new Movie ();
		movie2.Title = "Ace Ventura: When Nature Calls";
		movie2.ReleaseDate = DateTime.Parse ("11/10/1995");
		movie2.Rating = 5;

		List<Movie> movies = new List<Movie> () { movie, movie2 };

		SerializeToXML (movies);

		List<Movie> newMovies = DeserializeFromXML ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	static public void SerializeToXML(List<Movie> movies)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<Movie>));
		TextWriter textWriter = new StreamWriter("Assets/GameSheet.xml");
		serializer.Serialize(textWriter, movies);
		textWriter.Close();
	}

	static List<Movie> DeserializeFromXML()
	{
		XmlSerializer deserializer = new XmlSerializer (typeof(List<Movie>));
		TextReader textReader = new StreamReader ("Assets/GameSheet.xml");
		List<Movie> movies;
		movies = (List<Movie>)deserializer.Deserialize (textReader);
		textReader.Close ();

		print ("Deserialized movies: " + movies);

		return movies;
	}
}

public class Movie
{
	[XmlAttribute("MovieName")]
	public string Title
	{ get; set; }

	[XmlElement("MovieRating")]
	public int Rating
	{ get; set; }

	[XmlElement("MovieReleaseDate")]
	public DateTime ReleaseDate
	{ get; set; }
}




