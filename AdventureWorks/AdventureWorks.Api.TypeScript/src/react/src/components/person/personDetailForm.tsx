import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PersonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PersonDetailComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PersonDetailComponent extends React.Component<
  PersonDetailComponentProps,
  PersonDetailComponentState
> {
  state = {
    model: new PersonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.People + '/edit/' + this.state.model!.businessEntityID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.People +
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
          let response = resp.data as Api.PersonClientResponseModel;

          console.log(response);

          let mapper = new PersonMapper();

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
      return <Spin size="large" />;
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
              <h3>AdditionalContactInfo</h3>
              <p>{String(this.state.model!.additionalContactInfo)}</p>
            </div>
            <div>
              <h3>BusinessEntityID</h3>
              <p>{String(this.state.model!.businessEntityID)}</p>
            </div>
            <div>
              <h3>Demographics</h3>
              <p>{String(this.state.model!.demographic)}</p>
            </div>
            <div>
              <h3>EmailPromotion</h3>
              <p>{String(this.state.model!.emailPromotion)}</p>
            </div>
            <div>
              <h3>FirstName</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>LastName</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
            <div>
              <h3>MiddleName</h3>
              <p>{String(this.state.model!.middleName)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>NameStyle</h3>
              <p>{String(this.state.model!.nameStyle)}</p>
            </div>
            <div>
              <h3>PersonType</h3>
              <p>{String(this.state.model!.personType)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Suffix</h3>
              <p>{String(this.state.model!.suffix)}</p>
            </div>
            <div>
              <h3>Title</h3>
              <p>{String(this.state.model!.title)}</p>
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

export const WrappedPersonDetailComponent = Form.create({
  name: 'Person Detail',
})(PersonDetailComponent);


/*<Codenesium>
    <Hash>d641d4909a9eb28f04e6ac96c5757476</Hash>
</Codenesium>*/