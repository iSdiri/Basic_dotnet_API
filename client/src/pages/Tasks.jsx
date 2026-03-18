import { useState, useEffect } from 'react';
import api from '../services/api';
import { useNavigate } from 'react-router-dom';

export default function Tasks() {
  const [tasks, setTasks] = useState([]);
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const navigate = useNavigate();

  const fetchTasks = async () => {
    try {
      const res = await api.get('/task');
      setTasks(res.data);
    } catch {
      navigate('/login');
    }
  };

  const createTask = async () => {
    if (!title) return;
    await api.post('/task', { title, description, userId: 1 });
    setTitle('');
    setDescription('');
    fetchTasks();
  };

  const toggleComplete = async (task) => {
    await api.put(`/task/${task.id}`, {
      title: task.title,
      description: task.description,
      isCompleted: !task.isCompleted
    });
    fetchTasks();
  };

  const deleteTask = async (id) => {
    await api.delete(`/task/${id}`);
    fetchTasks();
  };

  const logout = () => {
    localStorage.removeItem('token');
    navigate('/login');
  };

  useEffect(() => { fetchTasks(); }, []);

  return (
    <div style={styles.container}>
      <div style={styles.header}>
        <h2>My Tasks</h2>
        <button style={styles.logout} onClick={logout}>Logout</button>
      </div>

      <div style={styles.form}>
        <input style={styles.input} placeholder="Title" value={title} onChange={e => setTitle(e.target.value)} />
        <input style={styles.input} placeholder="Description" value={description} onChange={e => setDescription(e.target.value)} />
        <button style={styles.button} onClick={createTask}>Add Task</button>
      </div>

      <div style={styles.list}>
        {tasks.map(task => (
          <div key={task.id} style={styles.task}>
            <div style={styles.taskInfo}>
              <span style={{ textDecoration: task.isCompleted ? 'line-through' : 'none', fontWeight: 'bold' }}>
                {task.title}
              </span>
              <span style={styles.desc}>{task.description}</span>
            </div>
            <div style={styles.actions}>
              <button style={styles.complete} onClick={() => toggleComplete(task)}>
                {task.isCompleted ? '↩' : '✓'}
              </button>
              <button style={styles.delete} onClick={() => deleteTask(task.id)}>✕</button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

const styles = {
  container: { maxWidth: '600px', margin: '2rem auto', padding: '1rem' },
  header: { display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '1.5rem' },
  form: { display: 'flex', gap: '0.5rem', marginBottom: '1.5rem', flexWrap: 'wrap' },
  input: { flex: 1, padding: '0.6rem', borderRadius: '4px', border: '1px solid #ccc', fontSize: '1rem' },
  button: { padding: '0.6rem 1rem', background: '#4f46e5', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' },
  logout: { padding: '0.5rem 1rem', background: '#ef4444', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' },
  list: { display: 'flex', flexDirection: 'column', gap: '0.75rem' },
  task: { display: 'flex', justifyContent: 'space-between', alignItems: 'center', background: 'white', padding: '1rem', borderRadius: '8px', boxShadow: '0 1px 4px rgba(0,0,0,0.1)' },
  taskInfo: { display: 'flex', flexDirection: 'column', gap: '0.25rem' },
  desc: { fontSize: '0.85rem', color: '#666' },
  actions: { display: 'flex', gap: '0.5rem' },
  complete: { padding: '0.4rem 0.7rem', background: '#22c55e', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' },
  delete: { padding: '0.4rem 0.7rem', background: '#ef4444', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' },
};
