using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

public class ExcelReader : MonoBehaviour {

	public string filepath = "Assets/GameSheet.xml";

	// Use this for initialization
	void Start () {
		Monster monster = new Monster ();
		monster.Name = "Grop";
		monster.Health = 10;
		monster.Strength = 1;

		List<Monster> monsters = new List<Monster> () { monster };

		SerializeToXML (monsters);

		List<Monster> newMonsters = DeserializeFromXML ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	static public void SerializeToXML(List<Monster> monsters)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<Monster>));
		TextWriter textWriter = new StreamWriter("Assets/GameSheet.xml");
		serializer.Serialize(textWriter, monsters);
		textWriter.Close();
	}

	static List<Monster> DeserializeFromXML()
	{
		XmlSerializer deserializer = new XmlSerializer (typeof(List<Monster>));
		TextReader textReader = new StreamReader ("Assets/GameSheetExcel.xml");
//		List<Monster> monsters;
//		monsters = (List<Monster>)deserializer.Deserialize (textReader);
		List<Monster> monsters = new List<Monster> ();

//		print ("Deserialized monsters: " + monsters);
		print (textReader.ReadToEnd());
		textReader.Close ();

		return monsters;
	}
}

public class Monster
{
	[XmlAttribute("MonsterName")]
	public string Name
	{ get; set; }

	[XmlElement("MonsterHealth")]
	public int Health
	{ get; set; }

	[XmlElement("MonsterStrength")]
	public int Strength
	{ get; set; }
}




