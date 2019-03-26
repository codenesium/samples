
import * as React from 'react';
import { Alert } from 'antd'
import * as GlobalUtilities from '../lib/globalUtilities';

interface ErrorBoundaryComponentProps{
}

interface ErrorBoundaryComponentState{
  hasError:boolean;
}

export default class ErrorBoundary extends React.Component<ErrorBoundaryComponentProps, ErrorBoundaryComponentState>
{
    state = ({hasError: false });
  
    static getDerivedStateFromError(error:any) {
      return { hasError: true };
    }
  
    componentDidCatch(error:any, info:any) {
      GlobalUtilities.logError(error);
    }
  
    render() {
      if (this.state.hasError) {
        return <Alert message='An error occurred...' type='error' />;
      }
      else {
         return this.props.children; 
      }
    }
  }