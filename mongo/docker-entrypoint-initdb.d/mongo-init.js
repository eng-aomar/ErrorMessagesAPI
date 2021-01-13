use admin
db.auth("root", "example")
db.createCollection("messages", {})

db.messages.insert(
   [
     { text: "tes1", createdAt: ISODate("2017-10-13T10:53:53Z"), updatedAt: ISODate("2017-10-13T10:53:53Z") },
     { text: "test2", createdAt: ISODate("2017-10-13T10:53:53Z"), updatedAt: ISODate("2017-10-13T10:53:53Z") },
   ]
)