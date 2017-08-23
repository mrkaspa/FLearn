module Customer

type Customer = { Age : int }

let where filter ls =
    seq {
        for it in ls do
            if filter it then
                yield it }

let filterGt36 cust = cust.Age > 36

let filterCustomers: (seq<Customer> -> seq<Customer>) = 
    where filterGt36