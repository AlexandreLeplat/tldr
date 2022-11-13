import initialGrid from './InitialGrid';

const defaultState = {
	grid: initialGrid,
};

export default function reducer(state = defaultState, action) {
	const update = [];

	function calculateState(x, y) {
		let count = 0;
		for (let i = x - 1; i <= x + 1; i++) {
			for (let j = y - 1; j <= y + 1; j++) {
				if (
					(i != x || j != y) &&
					i >= 0 &&
					i < state.grid.length &&
					j >= 0 &&
					j < state.grid[i].line.length
				) {
					count += state.grid[i].line[j].value;
				}
			}
		}
		if (count == 3 || (count == 2 && state.grid[x].line[y].value)) return 1;
		else return 0;
	}

	if (action.type == 'CHANGE_TILE_STATE') {
		for (let x = 0; x < state.grid.length; x++) {
			update[x] = { x: state.grid[x].x, line: [] };
			for (let y = 0; y < state.grid[x].line.length; y++) {
				update[x].line[y] = {
					y: state.grid[x].line[y].y,
					value: state.grid[x].line[y].value,
				};
			}
		}
		const switchValue = 1 - state.grid[action.x].line[action.y].value;
		update[action.x].line[action.y].value = switchValue;
		return { ...state, grid: update };
	}

	if (action.type == 'ITERATE') {
		for (let x = 0; x < state.grid.length; x++) {
			update[x] = { x: state.grid[x].x, line: [] };
			for (let y = 0; y < state.grid[x].line.length; y++) {
				update[x].line[y] = {
					y: state.grid[x].line[y].y,
					value: calculateState(x, y),
				};
			}
		}
		return { ...state, grid: update };
	}

	if (action.type == 'RESET') {
		return { ...state, grid: initialGrid };
	}

	return state;
}
