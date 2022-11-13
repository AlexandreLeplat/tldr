import { NavLink } from 'react-router-dom';

export default function Menu() {
	return (
		<header>
			<nav>
				<h1>TLDR</h1>
				<ul className="mainMenu">
					<li>
						<NavLink to="/">Carte</NavLink>
					</li>
				</ul>
			</nav>
		</header>
	);
}
