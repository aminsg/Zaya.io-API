# Zaya link shortener sdk for .NetFramwork
using this package you can easily implement the [Zaya](https://zaya.io) link shortener in your .NetFramwork application.
## Installation

You can use the package by importing cs file or adding dll file into your project

## Usage
First you need to get your API key from [Zaya](https://zaya.io/developers/api)
### Initial construction
```c#
public Form()
{
    InitializeComponent();
    ZayaApiClient.Connect("your api key");
}  

// available classes: Link, Space, Domain, Account, Stats.
//The class is static and there is no need to create an instance of it

```
### Links (URLs)
```c#
//for Working with urls you can use these classes
ZayaApiClient.URL.AllUrl()
ZayaApiClient.URL.CreateUrl(string URL)
ZayaApiClient.URL.DetailUrl(int ID)
ZayaApiClient.URL.UpdateUrl(int ID,string New_URL)
ZayaApiClient.URL.DeleteUrl(int ID)

//For example you can easily shorten the link like this
private string shorten(string url)
{
    return ZayaApiClient.URL.CreateUrl(url);
}
```
### Domains
```c#
//for Working with Domains you can use these classes
ZayaApiClient.Domain.AllDomain()
ZayaApiClient.Domain.CreateDomain(string Domain_name)
ZayaApiClient.Domain.DetailsDomain(int ID)
ZayaApiClient.Domain.UpdateDomain(int ID,string New_URL)
ZayaApiClient.Domain.DeleteDomain(int ID)

//For example you can get a list of all domains or domain details you create in zaya.io
private string getlist(int id = -1)
{
    if (id != -1)
    {
        return ZayaApiClient.Domain.DetailsDomain(id);
    }
    else
    {
        return ZayaApiClient.Domain.AllDomain();
    }
}
```

### Topics
```c#
//for Working with Topics in zaya use these classes
ZayaApiClient.Topics.Topics()
ZayaApiClient.Topics.CreateTopic(string name, string color)
ZayaApiClient.Topics.DetailsTopic(int ID)
ZayaApiClient.Topics.UpdateTopic(int ID,string New_URL)
ZayaApiClient.Topics.DeleteTopic(int ID)

//For example you can create topic like this
private string create_topic()
{
    ZayaApiClient.Topics.CreateTopic("{your topic name}","{color hex code}")
}

```
### Stats
```c#
//for Working with Stats of each url use these classes
ZayaApiClient.stats.stats(int ID)
ZayaApiClient.stats.Clicks(int ID)
ZayaApiClient.stats.Referrers(int ID)
ZayaApiClient.stats.Countries(int ID)
ZayaApiClient.stats.Languages(int ID)
ZayaApiClient.stats.Browsers(int ID)
ZayaApiClient.stats.Devices(int ID)
ZayaApiClient.stats.OperatingSystems(int ID)

//For example you can get stats of url by id like this
private string state_detail(int id)
{
   return ZayaApiClient.stats.stats(id)
}

```
### Account
```c#
//for get the full account details
ZayaApiClient.Account.Details()

//For example 
private string Details()
{
   return ZayaApiClient.Account.Details()
}

```
## Documentation
See the [documentation](https://zaya.io/developers) for more details.
