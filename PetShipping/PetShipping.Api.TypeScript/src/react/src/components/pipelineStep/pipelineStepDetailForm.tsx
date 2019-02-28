import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepMapper from './pipelineStepMapper';
import PipelineStepViewModel from './pipelineStepViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {HandlerPipelineStepTableComponent} from '../shared/handlerPipelineStepTable'
	import {OtherTransportTableComponent} from '../shared/otherTransportTable'
	import {PipelineStepDestinationTableComponent} from '../shared/pipelineStepDestinationTable'
	import {PipelineStepNoteTableComponent} from '../shared/pipelineStepNoteTable'
	import {PipelineStepStepRequirementTableComponent} from '../shared/pipelineStepStepRequirementTable'
	



interface PipelineStepDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PipelineStepDetailComponentState {
  model?: PipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PipelineStepDetailComponent extends React.Component<
PipelineStepDetailComponentProps,
PipelineStepDetailComponentState
> {
  state = {
    model: new PipelineStepViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.PipelineSteps + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PipelineSteps +
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
          let response = resp.data as Api.PipelineStepClientResponseModel;

          console.log(response);

          let mapper = new PipelineStepMapper();

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
									 <div>
							<h3>name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>pipelineStepStatusId</h3>
							<p>{String(this.state.model!.pipelineStepStatusIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>shipperId</h3>
							<p>{String(this.state.model!.shipperIdNavigation!.toDisplay())}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>HandlerPipelineSteps</h3>
            <HandlerPipelineStepTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineSteps + '/' + this.state.model!.id + '/' + ApiRoutes.HandlerPipelineSteps}
			/>
         </div>
			 <div>
            <h3>OtherTransports</h3>
            <OtherTransportTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineSteps + '/' + this.state.model!.id + '/' + ApiRoutes.OtherTransports}
			/>
         </div>
			 <div>
            <h3>PipelineStepDestinations</h3>
            <PipelineStepDestinationTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineSteps + '/' + this.state.model!.id + '/' + ApiRoutes.PipelineStepDestinations}
			/>
         </div>
			 <div>
            <h3>PipelineStepNotes</h3>
            <PipelineStepNoteTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineSteps + '/' + this.state.model!.id + '/' + ApiRoutes.PipelineStepNotes}
			/>
         </div>
			 <div>
            <h3>PipelineStepStepRequirements</h3>
            <PipelineStepStepRequirementTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.PipelineSteps + '/' + this.state.model!.id + '/' + ApiRoutes.PipelineStepStepRequirements}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPipelineStepDetailComponent = Form.create({ name: 'PipelineStep Detail' })(
  PipelineStepDetailComponent
);

/*<Codenesium>
    <Hash>98eb68f82421aec8b18223cfd0f7cae5</Hash>
</Codenesium>*/