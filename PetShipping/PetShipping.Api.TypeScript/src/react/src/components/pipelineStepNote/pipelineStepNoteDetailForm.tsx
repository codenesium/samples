import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepNoteMapper from './pipelineStepNoteMapper';
import PipelineStepNoteViewModel from './pipelineStepNoteViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface PipelineStepNoteDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepNoteDetailComponentState {
  model?: PipelineStepNoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PipelineStepNoteDetailComponent extends React.Component<
PipelineStepNoteDetailComponentProps,
PipelineStepNoteDetailComponentState
> {
  state = {
    model: new PipelineStepNoteViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.PipelineStepNotes + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineStepNotes +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PipelineStepNoteClientResponseModel;

          console.log(response);

          let mapper = new PipelineStepNoteMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div style={{"marginBottom":"10px"}}>
							<h3>employeeId</h3>
							<p>{String(this.state.model!.employeeIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div>
							<h3>note</h3>
							<p>{String(this.state.model!.note)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>pipelineStepId</h3>
							<p>{String(this.state.model!.pipelineStepIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPipelineStepNoteDetailComponent = Form.create({ name: 'PipelineStepNote Detail' })(
  PipelineStepNoteDetailComponent
);

/*<Codenesium>
    <Hash>733cd48fa203e0c9fa1ef63b7285eb65</Hash>
</Codenesium>*/