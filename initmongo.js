use admin
db.auth('root', 'example')

db = db.getSiblingDB('messagesdb')
db.createCollection("messages", {})
//db.createUser({
//    user: 'admin',
//    pwd: 'admin',
//    roles: [
//        {
//            role: 'dbOwner',
//            db: 'test'
//        }
//    ]
//});

db.test.insert(
    [
        { text: "tes1", createdAt: ISODate("2017-10-13T10:53:53Z"), updatedAt: ISODate("2017-10-13T10:53:53Z") },
        { text: "test2", createdAt: ISODate("2017-10-13T10:53:53Z"), updatedAt: ISODate("2017-10-13T10:53:53Z") },
    ]
);