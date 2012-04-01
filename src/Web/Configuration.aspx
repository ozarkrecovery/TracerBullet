<%@ Page
	Language           = "C#"
	Inherits           = "System.Web.UI.Page"
%>

<html>
	<head>
		<title>Configuration</title>
		<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/Content/Site.css")%>" />
	</head>
	<body>
		<div id="page-container">
			<div id="header-container">
	            <header class="clearfix">
	                <h2><a href="/TracerBullet/" title="Tracer Bullet" rel="home">Tracer Bullet</a></h2>
	                <h3>Drug and Alcohol Recovery Program</h3>
	            </header>
	        </div>
	        <div id="menu-container">
            	<nav class="clearfix">
                	<ul>
                    	<li><a href="#home">Home</a></li>
                    	<li><a href="#about">About</a></li>
                    	<li><a href="#counselor">Counselors</a></li>
                	</ul>
            	</nav>
        	</div>
			<div id="body-container">
				<form name="configuration" action="Configuration.aspx" method="post">
					<p>Microsoft SQL Sever Database Connection String</p>
					<p><input type="text" name="connectionString" style="width:900px; max-width:95%;" /></p>
					<input type="submit" />
				</form>
			</div>
		</div>
		<div id="footer-container">
	        <footer class="clearfix">
	            <p>Tracer Bullet</p>
	        </footer>
	    </div>
	</body>
</html>