CREATE TABLE company (
                         id SERIAL PRIMARY KEY,
                         name VARCHAR(255) NOT NULL
);

CREATE TABLE department (
                            id SERIAL PRIMARY KEY,
                            name VARCHAR(255) NOT NULL,
                            companyid INT NOT NULL  REFERENCES company(id)ON DELETE CASCADE
);

CREATE TABLE branch (
                        id SERIAL PRIMARY KEY,
                        name VARCHAR(255) NOT NULL,
                        departmentid INT NOT NULL   REFERENCES department(id) ON DELETE CASCADE
);

CREATE TABLE employee (
                          id SERIAL PRIMARY KEY,
                          fullname VARCHAR(255) NOT NULL,
                          position VARCHAR(100),
                          salary DECIMAL(18, 2),
                          branchid INT NOT NULL REFERENCES branch(id) ON DELETE CASCADE

);

insert into company(name)values (@Name);


insert into department(name, companyid) values (@Name, @CompanyId);

insert into branch(name, departmentid) VALUES (@Name, @DepartmentId);

insert into employee(fullname, position, salary, branchid)values (@FullName, @Position, @Salary, @BranchId);
update employee set fullname=@FullName,position=@Position,salary=@Salary,branchid=@BranchId