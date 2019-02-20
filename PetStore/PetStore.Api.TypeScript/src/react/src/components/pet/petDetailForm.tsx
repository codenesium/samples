import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PetMapper from './petMapper';
import PetViewModel from './petViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface PetDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PetDetailComponentState {
  model?: PetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PetDetailComponent extends React.Component<
  PetDetailComponentProps,
  PetDetailComponentState
> {
  state = {
    model: new PetViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Pets + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Pets +
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
          let response = resp.data as Api.PetClientResponseModel;

          console.log(response);

          let mapper = new PetMapper();

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
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <div>acquiredDate</div>
              <div>{this.state.model!.acquiredDate}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>breedId</h3>
              <div>{this.state.model!.breedIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>description</div>
              <div>{this.state.model!.description}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>penId</h3>
              <div>{this.state.model!.penIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>price</div>
              <div>{this.state.model!.price}</div>
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

export const WrappedPetDetailComponent = Form.create({ name: 'Pet Detail' })(
  PetDetailComponent
);


/*<Codenesium>
    <Hash>79b7772ffb0543cb3e6fe7b33bb41a3a</Hash>
</Codenesium>*/