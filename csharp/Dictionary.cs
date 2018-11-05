
class myDictionary{

    void BestWayToSearchDictionary(){
        
        foreach(KeyValuePair<string, string> entry in myDictionary)
        {
            // do something with entry.Value or entry.Key
        }

        // Just Keys
        foreach(var item in myDictionary.Values)
        {
          foo(item);
        }

        // Just values
        foreach(var item in myDictionary.Values)
        {
          foo(item);
        }
    }
}