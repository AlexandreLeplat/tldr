import { useSelector, useDispatch } from 'react-redux';
import Button from 'react-bootstrap/Button';
import Tile from '../components/Tile';

export default function FullMap() {
	const dispatch = useDispatch();
	const grid = useSelector(state => state.grid);

	return (
		<div className="container">
			<header>
				<Button variant="primary" onClick={() => dispatch({ type: 'ITERATE' })}>
					Itérer
				</Button>
				<Button
					variant="outline-primary"
					onClick={() => dispatch({ type: 'RESET' })}
				>
					Reset
				</Button>
			</header>
			<table className="grid">
				<tbody>
					{grid.map(({ x, line }) => (
						<tr key={x}>
							{line.map(({ y, value }) => (
								<Tile key={y} x={x} y={y} value={value} />
							))}
						</tr>
					))}
				</tbody>
			</table>
		</div>
	);
}
