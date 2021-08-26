USE db_library

--activates using the correct database--

CREATE TABLE tbl_LibraryBranch (
	LibraryBranchID INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	LibraryBranchName VARCHAR(50) NOT NULL,
	LibraryBranchAddress NVARCHAR(100) NOT NULL
);

CREATE TABLE tbl_Borrower (
	BorrowerCardNo INT PRIMARY KEY NOT NULL IDENTITY (1000,1),
	BorrowerName VARCHAR(50) NOT NULL,
	BorrowerAddress NVARCHAR(100) NOT NULL,
	BorrowerPhone CHAR(10) NOT NULL
);

CREATE TABLE tbl_Publisher (
	PublisherName VARCHAR(50) PRIMARY KEY NOT NULL,
	PublisherAddress NVARCHAR(100) NOT NULL,
	PublisherPhone CHAR(10) NOT NULL
);

CREATE TABLE tbl_Books (
	BooksBookID INT PRIMARY KEY NOT NULL IDENTITY (2000,1),
	BooksTitle NVARCHAR(100) NOT NULL,
	BooksPublisherName VARCHAR(50) NOT NULL CONSTRAINT fk_PublisherName FOREIGN KEY REFERENCES tbl_Publisher(PublisherName) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE tbl_BookCopies (
	BookCopiesBookID INT NOT NULL CONSTRAINT fk_BookCopiesBookID FOREIGN KEY REFERENCES tbl_Books(BooksBookID) ON UPDATE CASCADE ON DELETE CASCADE,
	BookCopiesBranchID INT NOT NULL CONSTRAINT fk_LibraryBranchID FOREIGN KEY REFERENCES tbl_LibraryBranch(LibraryBranchID) ON UPDATE CASCADE ON DELETE CASCADE,
	BookCopiesNumberOfCopies INT NOT NULL
);

CREATE TABLE tbl_BookAuthors (
	BookAuthorsBookID INT NOT NULL CONSTRAINT fk_AuthorsBookID FOREIGN KEY REFERENCES tbl_Books(BooksBookID) ON UPDATE CASCADE ON DELETE CASCADE,
	BookAuthorsName VARCHAR(50) NOT NULL
);

CREATE TABLE tbl_BookLoans (
	BookLoansBookID INT NOT NULL CONSTRAINT fk_LoanBookID FOREIGN KEY REFERENCES tbl_Books(BooksBookID) ON UPDATE CASCADE ON DELETE CASCADE,
	BookLoansBranchID INT NOT NULL CONSTRAINT fk_LoanBranchID FOREIGN KEY REFERENCES tbl_LibraryBranch(LibraryBranchID) ON UPDATE CASCADE ON DELETE CASCADE,
	BookLoansCardNo INT NOT NULL CONSTRAINT fk_LoansCardNo FOREIGN KEY REFERENCES tbl_Borrower(BorrowerCardNo) ON UPDATE CASCADE ON DELETE CASCADE,
	BookLoansDateOut DATE NOT NULL,
	BookLoansDateDue DATE NOT NULL
);
--Created the necessary tables and their columns, primary keys, and foreign keys--

INSERT INTO tbl_LibraryBranch
	(LibraryBranchName, LibraryBranchAddress)
	VALUES
	('Holly Brooke', '14432 NW Valsetz Rd, Tigard, OR 97365'),
	('Princeton', '2220 SE Corner Way, Rochester, VI 78993'),
	('Sharpstown', '432 NE Tumble Ave, Mononoke, GA 95338'),
	('Mandela Memorial', '59930 SW Main St, Springfield, MI 82211'),
	('Neutrino Circus', '999 SW B St, Portland, MA 28331'),
	('Cherokee Community Center', '438 Tuliro Ave, Kansas City, MO 92885')
;

SELECT * FROM tbl_BookAuthors
SELECT * FROM tbl_BookCopies
SELECT * FROM tbl_BookLoans
SELECT * FROM tbl_Books
SELECT * FROM tbl_Borrower
SELECT * FROM tbl_LibraryBranch
SELECT * FROM tbl_Publisher

INSERT INTO tbl_Borrower
	(BorrowerName, BorrowerAddress, BorrowerPhone)
	VALUES
	('Ravi Ahuja', '17222 NE Crossings Way, Beaverton, OR 97008', 5038772789),
	('Daniel Rojas', '543 SE Center Ave, Tacoma, WA 92773', 5412232111),
	('Jolene King', '92384 SW Turtle Blvd, Alston, NY 74448', 5873002988),
	('Sarah Verde', '912 NE Rupture Falls Ave, Radiant, OH 84347', 2934333998),
	('Patrick Stephens', '23438 SE Makings Way, Cralver, AZ 74483', 8746999852),
	('Martel Jameson', '1235 NW Taulity St, Tallahassee, FL 82337', 7843329666),
	('Corrine Guardsley', '4895 NE Waco Way, Dallas, TX 47559', 2835561118),
	('Patricia Wang', '28993 SW Main St, San Francisco, CA 90344', 9893447528)
;

INSERT INTO tbl_Publisher
	(PublisherName, PublisherAddress, PublisherPhone)
	VALUES
	('TOR', '2833 NE Cranston Ave, Ogden, NJ 28114', 7361102980),
	('Valley Publishing', '188 NW Forsey St, Cambino, NM 37747', 8228229939),
	('Into The Mines', '45 Kraken Place, Cemeneerie, ID 89337', 1772889039),
	('Crepton and Company', '8790 S Veroc St, Juno, WI 27712', 9880338611),
	('Verily Reading', '1882 N Hoyt Blvd, Sheperd, ND 12773', 8002338177),
	('Apple a Day Publishing', '900 SE Turtle Dove Rd, Girnsey, WV 26661', 8992273655),
	('Read All Over', '3882 SW Rome Ave, Redding, CA 12776', 1908892002),
	('Yankee Standard', '902 N Broadway Ave, New York, NY 27883', 8001111123),
	('Bellamy, Morris, and Stockton', '555 NW Utopia Rd, Xavier, VI 28873', 8299999921),
	('Premier Publishers', '772 S Brockton Rd, Hamilton, NH 18227', 1912287767)
;

INSERT INTO tbl_Books
	(BooksTitle, BooksPublisherName)
	VALUES
	('Radiant Dawn', 'Valley Publishing'),
	('Argument of Kings', 'Premier Publishers'),
	('His Smile', 'Verily Reading'),
	('Spelunking 101', 'Into The Mines'),
	('99 Healthy Fruit Facts and How To Implement Them Into Your Diet', 'Apple a Day Publishing'),
	('The Sword, Sheath, and Bow', 'Crepton and Company'),
	('Mom?', 'Bellamy, Morris, and Stockton'),
	('Civil War: A History', 'Yankee Standard'),
	('The Lord of the Necklaces', 'TOR'),
	('Counting Animals for 2s and 3s', 'Read All Over'),
	('EZ Math for 5s and up!', 'Read All Over'),
	('The Stormdark Chronicle', 'TOR'),
	('Okinawa: Pacific Theater', 'Yankee Standard'),
	('The Lost Tribe', 'Bellamy, Morris, and Stockton'),
	('Enterprise of Fate', 'Crepton and Company'),
	('Gastro Intestinal Eating Plan', 'Apple a Day Publishing'),
	('Top 50 Deepest Caves', 'Into The Mines'),
	('Fabio and I', 'Verily Reading'),
	('When Lips Meet', 'Verily Reading'),
	('Call Me Turtle Man', 'Bellamy, Morris, and Stockton')
;

INSERT INTO tbl_BookAuthors
	(BookAuthorsBookID, BookAuthorsName)
	VALUES
	(2000, 'Stephon Harkless'),
	(2001, 'Alayna Storee'),
	(2002, 'Marcos Innaros'),
	(2003, 'Cindy Truttlefield'),
	(2004, 'Stephon Harkless'),
	(2005, 'Stephon Harkless'),
	(2006, 'Caitlyn L. Salvatore'),
	(2007, 'Terilisha Freeman'),
	(2008, 'Hope Lee'),
	(2009, 'Christopher Magnuv'),
	(2010, 'Christopher Magnuv'),
	(2011, 'Igor Steppenovski'),
	(2012, 'Dev Harjuk'),
	(2013, 'Terilisha Freeman'),
	(2014, 'Stephon Harkless'),
	(2015, 'Alayna Storee'),
	(2016, 'Hope Lee'),
	(2017, 'Dev Harjuk'),
	(2018, 'Igor Steppenovski'),
	(2019, 'Terilisha Freeman')
;

INSERT INTO tbl_BookCopies
	(BookCopiesBookID, BookCopiesBranchID, BookCopiesNumberOfCopies)
	VALUES
	(2000, 5, 2),
	(2001, 6, 15),
	(2002, 1, 4),
	(2003, 1, 22),
	(2004, 1, 3),
	(2005, 3, 6),
	(2006, 2, 5),
	(2007, 4, 11),
	(2008, 3, 2),
	(2009, 3, 14),
	(2010, 3, 23),
	(2011, 3, 4),
	(2012, 5, 9),
	(2013, 6, 8),
	(2014, 6, 34),
	(2015, 3, 17),
	(2016, 2, 2),
	(2017, 1, 3),
	(2018, 1, 6),
	(2019, 4, 7)
;

INSERT INTO tbl_BookLoans
	(BookLoansBookID, BookLoansBranchID, BookLoansCardNo, BookLoansDateOut, BookLoansDateDue)
	VALUES
	(2000, 1, 1004, '2021-03-14', '2021-07-14'),
	(2004, 3, 1003, '2021-02-01', '2021-06-01'),
	(2005, 2, 1007, '2020-12-28', '2021-04-28'),
	(2007, 4, 1007, '2021-01-04', '2021-05-04'),
	(2008, 2, 1001, '2021-04-28', '2021-08-28'),
	(2009, 2, 1000, '2021-04-15', '2021-08-15'),
	(2013, 6, 1006, '2021-01-22', '2021-05-22'),
	(2014, 5, 1005, '2020-10-30', '2021-02-28'),
	(2018, 5, 1002, '2021-02-10', '2021-06-10'),
	(2019, 3, 1007, '2019-11-16', '2020-03-16')
;
--inserted the necessary data into each table while maintaining the consistency of how each table is linked together--

SELECT * FROM ((tbl_BookLoans FULL OUTER JOIN tbl_Borrower ON tbl_BookLoans.BookLoansCardNo = tbl_Borrower.BorrowerCardNo) FULL OUTER JOIN tbl_Books ON tbl_BookLoans.BookLoansBookID = tbl_Books.BooksBookID)

--Query for making a table that lists the Title of a Book and the Author's Name--

SELECT tbl_Books.BooksTitle, tbl_BookAuthors.BookAuthorsName
FROM tbl_Books
INNER JOIN tbl_BookAuthors ON tbl_Books.BooksBookID = tbl_BookAuthors.BookAuthorsBookID