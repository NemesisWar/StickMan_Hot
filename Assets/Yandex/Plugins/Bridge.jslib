mergeInto(LibraryManager.library, {

  Hello: function () {
    console.log("Hello, man");
  },

  GiveMePlayerData: function () {
    myGameInstance.SendMessage('YandexPlugin','SetName',player.getName());
    myGameInstance.SendMessage('YandexPlugin','SetIcon',player.getPhoto("medium"));
  },

  GetLang: function () {
    var lang = ysdk.enviroment.i18n.lang;
    var bufferSize = lenghtBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer,bufferSize);
    return buffer;
  },


  SaveExternal: function (date) {
    var dateString = UTF8ToString(date);
    var myObj = JSON.parse(dateString);
    player.setData(myObj);
    console.log("Save");
  },

  LoadExternal: function () {
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      console.log("Load");
      myGameInstance.SendMessage('LevelChander','LoadPlayerInfo',myJSON);
    })
  },

  ShowAdversting: function(){
   ysdk.adv.showFullscreenAdv({
    callbacks: {
      onClose: function(wasShown) {
        console.log("------------CLOSE-------------");
        myGameInstance.SendMessage('LevelChander','ResumeGame');
      },
      onError: function(error) {
        console.log("------------ERROR-------------");
        myGameInstance.SendMessage('LevelChander','ResumeGame');
      }
    }
  }) 
 },

});