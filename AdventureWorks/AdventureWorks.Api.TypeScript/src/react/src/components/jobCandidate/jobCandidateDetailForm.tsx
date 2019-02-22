import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import JobCandidateMapper from './jobCandidateMapper';
import JobCandidateViewModel from './jobCandidateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface JobCandidateDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface JobCandidateDetailComponentState {
  model?: JobCandidateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class JobCandidateDetailComponent extends React.Component<
JobCandidateDetailComponentProps,
JobCandidateDetailComponentState
> {
  state = {
    model: new JobCandidateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.JobCandidates + '/edit/' + this.state.model!.jobCandidateID);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.JobCandidates +
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
          let response = resp.data as Api.JobCandidateClientResponseModel;

          console.log(response);

          let mapper = new JobCandidateMapper();

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
							<h3>BusinessEntityID</h3>
							<p>{String(this.state.model!.businessEntityID)}</p>
						 </div>
					   						 <div>
							<h3>JobCandidateID</h3>
							<p>{String(this.state.model!.jobCandidateID)}</p>
						 </div>
					   						 <div>
							<h3>ModifiedDate</h3>
							<p>{String(this.state.model!.modifiedDate)}</p>
						 </div>
					   						 <div>
							<h3>Resume</h3>
							<p>{String(this.state.model!.resume)}</p>
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

export const WrappedJobCandidateDetailComponent = Form.create({ name: 'JobCandidate Detail' })(
  JobCandidateDetailComponent
);

/*<Codenesium>
    <Hash>a572522c71d23a23ca75f8b00010f3e7</Hash>
</Codenesium>*/