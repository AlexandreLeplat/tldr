import { Routes, Route } from 'react-router-dom';
import FullMap from './FullMap';

export default function Navigator() {
	return (
		<Routes>
			<Route path="/" element={<FullMap />} />
		</Routes>
	);
}
