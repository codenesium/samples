import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpaceMapper from './spaceMapper';
import SpaceViewModel from './spaceViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface SpaceDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpaceDetailComponentState {
  model?: SpaceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SpaceDetailComponent extends React.Component<
SpaceDetailComponentProps,
SpaceDetailComponentState
> {
  state = {
    model: new SpaceViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Spaces + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Spaces +
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
          let response = resp.data as Api.SpaceClientResponseModel;

          console.log(response);

          let mapper = new SpaceMapper();

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
            loaded: false,
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
      return <LoadingForm />;
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
							<div>description</div>
							<div>{this.state.model!.description}</div>
						 </div>
					   						 <div>
							<div>name</div>
							<div>{this.state.model!.name}</div>
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

export const WrappedSpaceDetailComponent = Form.create({ name: 'Space Detail' })(
  SpaceDetailComponent
);

/*<Codenesium>
    <Hash>1c0bc644ccc9f60489a8083c6b02aeb3</Hash>
</Codenesium>*/