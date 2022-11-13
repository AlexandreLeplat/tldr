import { useEffect } from 'react';
import { useDispatch } from 'react-redux';

const Tile = ({ x, y, value }) => {
	const dispatch = useDispatch();
	useEffect(() => {
		console.log('Nouvelle valeur à [' + x + ',' + y + '] : ' + value);
	}, [value]);
	const clickAction = {
		type: 'CHANGE_TILE_STATE',
		x: x,
		y: y,
	};

	return (
		<td
			className={`tile ${value ? 'active' : ''}`}
			onClick={() => dispatch(clickAction)}
		></td>
	);
};

export default Tile;
