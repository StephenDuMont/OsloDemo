﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chatbot.Dialogs
{

    public class UserInputInformation
    {
        public string query { get; set; }
        public Intent[] intents { get; set; }
        public Entity[] entities { get; set; }
        public override string  ToString()
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new {
                intents = intents?.Select(x => x.intent),
                entities = entities?.Select(x => x.entity) });
        }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }
        public Resolution resolution { get; set; }
    }

    public class Resolution
    {
        public string date { get; set; }
        public string duration { get; set; }
        public string time { get; set; }
        public string comment { get; set; }
    }
}